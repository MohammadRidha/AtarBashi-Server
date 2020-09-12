using AtarBashi.Common.Helpers;
using AtarBashi.Data.DTOs.Site.Admin.Photos;
using AtarBashi.Data.DTOs.Site.Admin.Prescriptions;
using AtarBashi.Data.DTOs.Site.Admin.Users;
using AtarBashi.Data.Models;
using AutoMapper;
using System.Linq;

namespace AtarBashi.Presentation.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt=>
                {

                    // IsMain yani aks profilesh bashe 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(src => src.DateOfBirth.ToAge());
                });
            CreateMap<Photo, PhotoForUserDetailedDto>();
            CreateMap<Prescription, PrescriptionForUserDetailedDto>();
        }
    }
}
