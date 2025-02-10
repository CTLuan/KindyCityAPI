using KindyCity.Domain.Entites;
using KindyCity.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByEmail(string Email);
        Task<EmployeeDto?> GetEmployeeByEmployeeCode(string EmployeeCode);

        Task CreateEmployee(Employee Employee); 
        Task CreateEmployeeInfo(EmployeeInfo employeeInfo); 
        Task CreateEmployeeEducation(EmployeeEducation employeeEducation);
        Task UpdateEmployee(Guid EmployeeId, Employee employee);
        Task<int> NumberOfEmployees();
    }
}
