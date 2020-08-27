using System;
using System.Threading.Tasks;
using AtarBashi.Data.Repositories.Interface;
using AtarBashi.Data.Repositories.Repo;
using Microsoft.EntityFrameworkCore;

namespace AtarBashi.Data.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext: DbContext, new()  
    {
        #region ctor

        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }
        #endregion

        #region privateRepository

        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_db);
                }
                return userRepository;
            }

        }
        #endregion

        #region Save

        public void Save()
        {
            _db.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        #endregion

        #region Disposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
