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
    public class AuthRepository : IAuthRepository
    {
        private readonly KindyCityContext _db;

        public AuthRepository(KindyCityContext db)
        {
            _db = db;
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _db.AddAsync(employee);
        }

        public async Task<EmployeeRefreshToken> AddEmployeeRefreshToken(EmployeeRefreshToken request)
        {
            await _db.AddAsync(request);
            return request;
        }

        public async Task<EmployeeRefreshToken?> GetEmployeeRefreshToken(Guid DeviceId, Guid EmployeeId)
        {
            var result = await _db.EmployeeRefreshTokens.Where(x => x.DeviceId == DeviceId && x.EmployeeId == EmployeeId).FirstOrDefaultAsync();

            return result;
        }

        public void UpdateEmployeeRefreshToken(Guid RefreshTokenId, EmployeeRefreshToken request)
        {
            var data = _db.EmployeeRefreshTokens.FirstOrDefault(x =>x.RefreshTokenId == RefreshTokenId);

            data.RefreshToken = request.RefreshToken;
            data.Expires = DateTime.Now.AddDays(7);
            data.CreateAt = DateTime.Now;

            if (data != null)
                _db.EmployeeRefreshTokens.Update(data);
        }
    }
}
