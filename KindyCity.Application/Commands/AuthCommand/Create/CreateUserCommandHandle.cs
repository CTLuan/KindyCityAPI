using AutoMapper;
using KindyCity.Application.Models.Response;
using KindyCity.Domain.Entites;
using KindyCity.Domain.Enums;
using KindyCity.Domain.Interfaces;
using KindyCity.Shared.Configurations;
using KindyCity.Shared.Exceptions;
using KindyCity.Shared.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Commands.Auth.Create
{
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, EmployeeResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public CreateUserCommandHandle(IUnitOfWork unitOfWork, 
                                       IMapper mapper,
                                       IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<EmployeeResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await EmployeeExits(request.Email);

            var passworkSalt = PasswordHelper.GenerateSalt();
            var passwordHash = PasswordHelper.HashPasswordWithSalt (request.Password, passworkSalt);

            var employee = CreateEmployeeEntity(request, passworkSalt, passwordHash);

            await _unitOfWork.AuthRepository.CreateEmployee(employee);

            await _unitOfWork.CommitAsync();

            //var roles = new List<string> { "Admin", "Guest" };

            //var jwtToken = GenerateJwtToken(employee.EmployeeId, employee.Email, roles);

            var response = _mapper.Map<EmployeeResponseDto>(employee);
            //response.Token = jwtToken;

            return await Task.FromResult(response);
        }

        private async Task<bool> EmployeeExits(string email)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetEmployeeByEmail(email);
            if (employee is not null) 
                throw new ConflictException($"The email '{email}' is already registered.");
            return false;
        }

        private Employee CreateEmployeeEntity(CreateUserCommand request, string salt, string hash)
        {
            var employee = _mapper.Map<Employee>(request);
            employee.PasswordSalt = salt;
            employee.PasswordHash = hash;
            employee.EmployeeId = Guid.NewGuid();
            employee.Avatar = string.Empty;
            employee.Status = EmployeeStatus.Absent;

            return employee;
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


    }
}
