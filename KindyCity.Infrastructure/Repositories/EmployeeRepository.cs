using KindyCity.Application.Models.Response;
using KindyCity.Domain.Entites;
using KindyCity.Infrastructure.Data;
using KindyCity.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly KindyCityContext _db;

        public async Task<Employee?> GetEmployeeByEmail(string email)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(x => x.Email == email);
            return employee;
        }

        public async Task<EmployeeDto?> GetEmployeeByEmployeeCode(string EmployeeCode)
        {
            var employee = await _db.Employees.Include(x => x.EmployeeInfo).FirstOrDefaultAsync();

            if (employee is null || employee.EmployeeInfo is null)
                return null;

            var result = new EmployeeDto()
            {
                EmployeeCode = employee.EmployeeInfo.EmployeeCode,
                Email = employee.Email,
                Name = employee.EmployeeInfo.FullName,
            };

            return result;
        }

        public EmployeeRepository(KindyCityContext db)
        {
            _db = db;
        }
        public async Task CreateEmployee(Employee employee)
        {
            await _db.AddAsync(employee);
        }

        public async Task CreateEmployeeEducation(EmployeeEducation employeeEducation)
        {
            await _db.EmployeeEducations.AddAsync(employeeEducation);
        }

        public async Task CreateEmployeeInfo(EmployeeInfo employeeInfo)
        {
            await _db.EmployeeInfos.AddAsync(employeeInfo);
        }

        public async Task<int> NumberOfEmployees()
        {
            var result = await _db.Employees.CountAsync();
            return result;

        }

        public async Task UpdateEmployee(Guid EmployeeId, Employee employee)
        {
            _db.Employees.Update(employee);
        }
    }
}
