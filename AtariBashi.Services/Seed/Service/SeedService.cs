using AtarBashi.Common.Helpers;
using AtarBashi.Data.DataBaseContext;
using AtarBashi.Data.Infrastructure;
using AtarBashi.Data.Models;
using AtarBashi.Services.Seed.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AtarBashi.Services.Seed.Service
{
   public  class SeedService: ISeedService
    {
        private readonly IUnitOfWork<AtarBashiDbContext> _db;

        public SeedService(IUnitOfWork<AtarBashiDbContext> dbContext)
        {
            _db = dbContext;
        }

        public void SeedUsers()
        {
            var userData = File.ReadAllText("Files/Json/Seed/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<IList<User>>(userData);

            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                Utilities.CreatePasswordHash("123456", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                user.UserName = user.UserName.ToLower();

                 _db.UserRepository.Insert(user);
            }
            _db.Save();
        }

        public async Task SeedUsersAsync()
        {
            var userData = File.ReadAllText("Files/Json/Seed/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<IList<User>>(userData);

            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                Utilities.CreatePasswordHash("123456", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                user.UserName = user.UserName.ToLower();

                await _db.UserRepository.InsertAsync(user);
            }

            await _db.SaveAsync();
        }
    }
}
