using AtarBashi.Common.Helpers;
using AtarBashi.Data.DataBaseContext;
using AtarBashi.Data.Infrastructure;
using AtarBashi.Data.Models;
using AtarBashi.Services.Site.Admin.Auth.Interfaces;
using System.Threading.Tasks;

namespace AtarBashi.Services.Site.Admin.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork<AtarBashiDbContext> _db;
        public AuthService(IUnitOfWork<AtarBashiDbContext> dbContext)
        {
            _db = dbContext;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _db.UserRepository.GetAsync(p => p.UserName == username);
            if (user == null)
            {
                return null;
            }
            if (!Utilities.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordhash, passwordSalt;
            Utilities.CreatePasswordHash(password, out passwordhash, out passwordSalt);

            user.PasswordHash = passwordhash;
            user.PasswordSalt = passwordSalt;

            await _db.UserRepository.InsertAsync(user);
            await _db.SaveAsync();

            return user;
        }
    }
}
