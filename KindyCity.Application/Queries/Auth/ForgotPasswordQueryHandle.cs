using KindyCity.Application.Interfaces;
using KindyCity.Application.Models.Response;
using KindyCity.Domain.Entites;
using KindyCity.Domain.Interfaces;
using KindyCity.Shared.Models;
using KindyCity.Shared.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Queries.Auth
{
    public class ForgotPasswordQueryHandle : IRequestHandler<ForgotPasswordQuery, ForgotPasswordDto>
    {
        private readonly IRedisService _redisService;
        private readonly IUnitOfWork _unitOfWork;

        public ForgotPasswordQueryHandle(IRedisService redisService,
                                         IUnitOfWork unitOfWork)
        {
            _redisService = redisService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ForgotPasswordDto> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {

            var employee = await GetEmployeeByEmail(request.Email);
            if (employee is null)
                return new ForgotPasswordDto();

            var key = $"otp:{employee.Email}";

            var otp = GenerateOtp();

            _redisService.Save(key, otp, TimeSpan.FromMinutes(5));

            var result = new ForgotPasswordDto()
            {
                EmployeeId = employee.EmployeeId,
                OTP = otp,
            };

            string apiUrl = "https://api1-sms.cmctelecom.vn/SMS_CMCTelecom/api/sms/send";
            string brandName = "KINDYCITY";
            string message = $"Otp forgot password is {result.OTP}";
            string phoneNumber = "0373341703";
            string username = "kindycityapi";
            string password = PasswordHelper.HashPassword("Gu9#w2x8A"); // Nếu cần băm mật khẩu thì xử lý trước khi gửi

            var statusSendSMS = await SendSMSHelper.SendSmsAsync(apiUrl, brandName, message, phoneNumber, username, password);

            return result;
        }

        private string GenerateOtp()
        {
            var random = new Random();
            int min = 11111, max = 99999;
            int randomNumber = random.Next(min, max);

            return randomNumber.ToString();
        }

        private  async Task<Employee?> GetEmployeeByEmail (string Email)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetEmployeeByEmail(Email);
            return employee;
        }


    }
}
