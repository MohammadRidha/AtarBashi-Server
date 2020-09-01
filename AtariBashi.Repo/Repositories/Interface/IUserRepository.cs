using AtarBashi.Data.Infrastructure;
using AtarBashi.Data.Models;
using System.Threading.Tasks;

namespace AtarBashi.Repo.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExists(string username);
    }
}
