using System.Threading.Tasks;
using AtarBashi.Data.DataBaseContext;
using AtarBashi.Data.Infrastructure;
using AtarBashi.Data.Models;
using AtarBashi.Repo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AtarBashi.Repo.Repositories.Repo
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        private readonly DbContext _db;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _db = _db ?? (AtarBashiDbContext)_db;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await GetAsync(p => p.UserName == username) != null)
                return true;

            return false;



        }
    }
}
