using AutoMapper;
using KindyCity.Domain.Entites;
using KindyCity.Domain.Interfaces;
using KindyCity.Shared.Models;
using KindyCity.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Commands.EmployeeCommand.Create
{
    public class CreateEmployeeCommandHandle : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeCommandHandle(IMapper mapper,
                                           IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            request.EmployeeCode = await CreateEmployeeCode();

            var employeeInfo = await ProcessEmployeeInfo(request);

            var employee = await ProcessEmployee(request, employeeInfo);

            await ProcessEmployeeEducation(request, employee.EmployeeId);

            await _unitOfWork.CommitAsync();
            var response = new EmployeeDto();
            return response;
        }

        private async Task<EmployeeInfo> ProcessEmployeeInfo(CreateEmployeeCommand request)
        {
            var employeeInfo = _mapper.Map<EmployeeInfo>(request);
            employeeInfo.EmployeeId = Guid.NewGuid();
            await _unitOfWork.EmployeeRepository.CreateEmployeeInfo(employeeInfo);
            return employeeInfo;
        }

        private async Task<Employee> ProcessEmployee(CreateEmployeeCommand request, EmployeeInfo employeeInfo)
        {
            var employee = _mapper.Map<Employee>(request);
            employee.EmployeeId = employeeInfo.EmployeeId;
            employee.PasswordSalt = PasswordHelper.GenerateSalt();
            employee.PasswordHash = PasswordHelper.HashPasswordWithSalt("Kindy@123", employee.PasswordSalt);

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UpLoads/Avatar");
            employee.Avatar = await SaveFile(request.Avatar, uploadsFolder, request.EmployeeCode);

            await _unitOfWork.EmployeeRepository.CreateEmployee(employee);
            return employee;
        }

        private async Task ProcessEmployeeEducation(CreateEmployeeCommand request, Guid employeeId)
        {
            var employeeEducation = _mapper.Map<EmployeeEducation>(request);
            employeeEducation.EmployeeId = employeeId;
            employeeEducation.EmployeeEducationId = Guid.NewGuid();
            await _unitOfWork.EmployeeRepository.CreateEmployeeEducation(employeeEducation);
        }

        private async Task<string> SaveFile(IFormFile file, string folderPath, string fileNamePrefix)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("No file uploaded.");
            }

            // Đảm bảo thư mục tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Tạo tên file duy nhất
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{fileNamePrefix}_{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(folderPath, fileName);

            // Lưu file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/UpLoads/Avatar/{fileName}";
        }


        
        private async Task<string> CreateEmployeeCode()
        {
            var numberOfEmployees = await _unitOfWork.EmployeeRepository.NumberOfEmployees();
            if (numberOfEmployees == 0)
                numberOfEmployees = 1;

            var emeCode = "EME" + (numberOfEmployees + 1).ToString().PadLeft(4, '0');

            return emeCode;
        }
    }
}
