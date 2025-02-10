using KindyCity.Application.Models.Response;
using KindyCity.Domain.Entites;
using KindyCity.Domain.Interfaces;
using KindyCity.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Queries.Auth
{
    public class RefreshTokenQueryHandle : IRequestHandler<RefreshTokenQuery, ApiResponse<RefreshTokenResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public RefreshTokenQueryHandle(IUnitOfWork unitOfWork,
                                       IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<ApiResponse<RefreshTokenResponse>> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var employee = await GetEmployee(request.Email);

            if (employee is null)
                return new ApiResponse<RefreshTokenResponse> { Success = false, Data = null, Message = "Token is incorrect or has expired" };

            var employeeToken = await GetRefreshToken(request.DeviceId, employee.EmployeeId);
            if (employeeToken is null)
                return new ApiResponse<RefreshTokenResponse> { Success = false, Data = null, Message = "Token is incorrect or has expired" };

            var employeeRoles = EmployeeRoles(employee.EmployeeId);
            var accessToken = GenerateJwtToken(employee.EmployeeId, employee.Email, employeeRoles);
            var refreshToken = RefreshToken();

            UpdateRefreshToken(employeeToken);

            await _unitOfWork.CommitAsync();

            var response = new RefreshTokenResponse()
            {
                DeviceId = request.DeviceId,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return new ApiResponse<RefreshTokenResponse>()
            {
                Success = true,
                Message = "RefreshToken success",
                Data = response
            };
        }

        private async Task<EmployeeRefreshToken?> GetRefreshToken(Guid DeviceId, Guid EmployeeId)
        {
            var result = await _unitOfWork.AuthRepository.GetEmployeeRefreshToken(DeviceId, EmployeeId);

            if (result is null || DateTime.Now > result.Expires)
                return null;

            return result;
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

        private async Task<Employee?> GetEmployee(string Email)
        {
            var result = await _unitOfWork.EmployeeRepository.GetEmployeeByEmail(Email);
            return result;
        }

        private List<string> EmployeeRoles(Guid EmployeeId)
        {
            var roles = new List<string> { "Admin", "Guest" };
            return roles;
        }

        private string RefreshToken()
        {
            var result = _jwtService.GenerateRefreshToken();
            return result;
        }

        private void UpdateRefreshToken(EmployeeRefreshToken RefreshToken)
        {
            _unitOfWork.AuthRepository.UpdateEmployeeRefreshToken(RefreshToken.RefreshTokenId, RefreshToken);
        }
    }
}
