using AutoMapper;
using KindyCity.Application.Interfaces;
using KindyCity.Domain.Entites;
using KindyCity.Domain.Interfaces;
using KindyCity.Shared.Utilities;
using MediatR;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KindyCity.Application.Commands.AuthCommand.Update
{
    public class ResetPasswordQueryHandle : IRequestHandler<ResetPasswordQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRedisService _redisService;

        public ResetPasswordQueryHandle(IUnitOfWork unitOfWork,
                                        IMapper mapper,
                                        IRedisService redisService)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
            _redisService = redisService;
        }

        public async Task<bool> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var employee = await GetEmployeeByEmail(request.Email);
            if (employee is null)
                return false;

            var validateOtp = ValidateOtp(request.Email, request.Otp);

            if (!validateOtp)
                return false;

            var passwordSalt = PasswordHelper.GenerateSalt();
            var passwordHash = PasswordHelper.HashPasswordWithSalt(request.Password, passwordSalt);

            employee.Email = request.Email;
            employee.PasswordHash = passwordHash;
            employee.PasswordSalt = passwordSalt;


            await _unitOfWork.EmployeeRepository.UpdateEmployee(employee.EmployeeId, employee);

            await _unitOfWork.CommitAsync();
            return true;
        }

        private async Task<Employee?> GetEmployeeByEmail(string Email)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetEmployeeByEmail(Email);

            return employee;
        }

        private bool ValidateOtp(string Email, string Otp)
        {
            var redisValue = _redisService.Get(Email);
            if (redisValue is null) return false;

            if (redisValue == Otp)
                return true;
            return false;
        }
    }
}
