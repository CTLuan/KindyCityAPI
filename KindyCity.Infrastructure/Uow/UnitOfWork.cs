using KindyCity.Domain.Interfaces;
using KindyCity.Infrastructure.Data;
using KindyCity.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KindyCityContext _db;

        // Thuộc tính được khởi tạo từ constructor
        public IAuthRepository AuthRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }


        public UnitOfWork(KindyCityContext db, IAuthRepository authRepository, IEmployeeRepository employeeRepository)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            AuthRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
            EmployeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<int> CommitAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            //_db.Dispose();
        }

        public Task RollbackAsync()
        {
            return Task.CompletedTask;
        }
    }
}
