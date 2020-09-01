using AtarBashi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtarBashi.Services.Site.Admin.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
    }
}
