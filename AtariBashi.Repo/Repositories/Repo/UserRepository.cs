using AtarBashi.Data.DataBaseContext;
using AtarBashi.Data.Infrastructure;
using AtarBashi.Data.Models;
using AtarBashi.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AtarBashi.Data.Repositories.Repo
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        private readonly DbContext _db;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (_db ?? (AtarBashiDbContext)_db);
        }
    }
}
