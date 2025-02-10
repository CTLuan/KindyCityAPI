using KindyCity.Domain.Entites;
using KindyCity.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Infrastructure.Repositories
{
    public interface IAuthRepository
    {
        Task CreateEmployee(Employee Employee); 
        Task<EmployeeRefreshToken> AddEmployeeRefreshToken(EmployeeRefreshToken request);
        Task<EmployeeRefreshToken?> GetEmployeeRefreshToken(Guid DeviceId, Guid EmployeeId);
        void UpdateEmployeeRefreshToken(Guid RefreshTokenId, EmployeeRefreshToken request);
    }
}
