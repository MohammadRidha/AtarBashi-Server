using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtarBashi.Data.DataBaseContext;
using AtarBashi.Data.DTOs.Site.Admin.Users;
using AtarBashi.Data.Infrastructure;
using AtarBashi.Services.Site.Admin.Auth.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork<AtarBashiDbContext> dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _db.UserRepository.GetManyAsync(null, null, "Photos,Prescriptions");
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {

            // automapper: ye vaghti ma ye model darim ke balaye 50ta prop dashtte bashe nemitonim 50ta ro new bokonim
            // leza az automapper estefadeh mikonim.yek model pichideh be model sadeh tabdil mikonim
            // to startup.cs activesh mikonim 
            // baad bayad berim ye folder besazim da presentation : Helpers > class
            var user = await _db.UserRepository.GetManyAsync(p=>p.Id == id, null, "Photos");
            var userToReturn = _mapper.Map<UserForDetailedDto>(user.SingleOrDefault());
            return Ok(userToReturn);
        }
    }
}