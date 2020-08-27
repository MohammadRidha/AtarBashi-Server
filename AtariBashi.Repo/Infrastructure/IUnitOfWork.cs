using AtarBashi.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AtarBashi.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext:DbContext
    {
        IUserRepository UserRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
