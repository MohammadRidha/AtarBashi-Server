using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AtarBashi.Data.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> , IDisposable where TEntity : class
    {

        #region ctor
        private readonly DbContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        #endregion

        #region Normal
        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }
        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Async

        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region dispose
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

        ~Repository()
        {
            Dispose(false);
        }
        #endregion
    }
}
