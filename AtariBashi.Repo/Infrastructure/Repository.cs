using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _dbSet.Add(entity);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }
        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("There is no entity");
            _dbSet.Update(entity);
        }
        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new ArgumentException("There is no entity");
            _dbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);

        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objs = _dbSet.Where(where).AsEnumerable();
            foreach (TEntity item in objs)
            {
                _dbSet.Remove(item);
            }
        }
        #endregion

        #region Async
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }
     
        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
       
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
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
