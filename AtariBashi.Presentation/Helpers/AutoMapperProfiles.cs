using AtarBashi.Data.DTOs.Site.Admin.Users;
using AtarBashi.Data.Models;
using AutoMapper;

namespace AtarBashi.Presentation.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
        }
    }
}
