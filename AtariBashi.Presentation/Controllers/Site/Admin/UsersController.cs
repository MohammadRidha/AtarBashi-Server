using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtarBashi.Data.DataBaseContext;
using AtarBashi.Data.Infrastructure;
using AtarBashi.Services.Site.Admin.Auth.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AtarBashi.Presentation.Controllers.Site.Admin
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "Site")]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUnitOfWork<AtarBashiDbContext> _db;

        public UsersController(IUnitOfWork<AtarBashiDbContext> dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _db.UserRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _db.UserRepository.GetByIdAsync(id);
            return Ok(user);
        }
    }
}