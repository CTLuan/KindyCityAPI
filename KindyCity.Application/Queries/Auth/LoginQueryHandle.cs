using AutoMapper;
using KindyCity.Application.Models.Response;
using KindyCity.Domain.Entites;
using KindyCity.Domain.Interfaces;
using KindyCity.Shared.Constants;
using KindyCity.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Queries.Auth
{
    public class LoginQueryHandle : IRequestHandler<LoginQuery, ApiResponse<EmployeeResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public LoginQueryHandle(IUnitOfWork unitOfWork,
                                IMapper mapper,
                                IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<ApiResponse<EmployeeResponseDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var employee = await GetEmployeeByEmail(request.Email);
            if (employee is null)
                return new ApiResponse<EmployeeResponseDto>()
                {
                    Success = false,
                    Data = null,
                    Message = "Username or password is not valid"
                };

            var verifyPassword = PasswordHelper.VerifyPassword(request.Password, employee.PasswordSalt, employee.PasswordHash);
            if (!verifyPassword)
                return new ApiResponse<EmployeeResponseDto>()
                {
                    Success = false,
                    Data = null,
                    Message = "Username or password is not valid"
                };


            var employeeRoles = EmployeeRoles(employee.EmployeeId);

            var jwtToken = GenerateJwtToken(employee.EmployeeId, employee.Email, employeeRoles);
            var refreshToken = GenerateRefreshToken();
            await HandleRefreshToken(request.DeviceId, request.DeviceInfo, refreshToken, employee.EmployeeId);

            await _unitOfWork.CommitAsync();
            var response = _mapper.Map<EmployeeResponseDto>(employee);
            response.AccessToken = jwtToken;
            response.RefreshToken = refreshToken;

            //return await Task.FromResult(response);
            return new ApiResponse<EmployeeResponseDto>()
            {
                Success = true,
                Data = response,
                Message = "Login success"
            };
        }

        private async Task<Employee?> GetEmployeeByEmail(string Email)
        {
            return await _unitOfWork.EmployeeRepository.GetEmployeeByEmail(Email);
        }

        private string GenerateJwtToken(Guid EmployeeId, string Email, List<string> Roles)
        {
            var initialClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, EmployeeId.ToString()),
                new Claim(ClaimTypes.Email, Email)
            };

            foreach (var role in Roles)
            {
                initialClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = _jwtService.GenerateAccessToken(initialClaims);
            return token;
        }

        private string GenerateRefreshToken()
        {
            return _jwtService.GenerateRefreshToken();  
        }

        private async Task HandleRefreshToken(Guid DeviceId, string DeviceInfo, string RefreshToken, Guid EmployeeId)
        {
            var result = await GetRefreshToken(DeviceId, EmployeeId);

            if (result is null)
                await AddEmployeeRefreshToken(DeviceId, DeviceInfo, RefreshToken, EmployeeId);
            else
                UpdateRefreshToken(result.RefreshTokenId, DeviceInfo, RefreshToken, result.EmployeeId);
        }

        private async Task AddEmployeeRefreshToken(Guid DeviceId, string DeviceInfo, string RefreshToken, Guid EmployeeId)
        {
            var employeeRefreshToken = new EmployeeRefreshToken()
            {
                RefreshTokenId = Guid.NewGuid(),
                DeviceId = DeviceId,
                DeviceInfo = DeviceInfo,
                IsRevoked = false,
                Expires = DateTime.Now.AddDays(7),
                CreateAt = DateTime.Now,
                RefreshToken = RefreshToken,
                EmployeeId = EmployeeId
            };

            await _unitOfWork.AuthRepository.AddEmployeeRefreshToken(employeeRefreshToken);
        }

        private async Task<EmployeeRefreshToken?> GetRefreshToken(Guid DeviceId, Guid EmployeeId)
        {
            var result = await _unitOfWork.AuthRepository.GetEmployeeRefreshToken(DeviceId, EmployeeId);
            return result;
        }

        private List<string> EmployeeRoles(Guid EmployeeId)
        {
            var roles = new List<string> { "Admin", "Guest" };
            return roles;
        }

        private void UpdateRefreshToken(Guid RefreshTokenId, string DeviceInfo, string RefreshToken, Guid EmployeeId)
        {
            var request = new EmployeeRefreshToken()
            {
                RefreshToken = RefreshToken,
                CreateAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(7),
                DeviceInfo = DeviceInfo,
                IsRevoked = false
            };

            _unitOfWork.AuthRepository.UpdateEmployeeRefreshToken(RefreshTokenId, request);

        }

    }
}
