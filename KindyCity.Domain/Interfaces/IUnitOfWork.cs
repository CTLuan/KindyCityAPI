using KindyCity.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository AuthRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
