using AtarBashi.Data.DTOs.Site.Admin.Photos;
using AtarBashi.Data.DTOs.Site.Admin.Prescriptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtarBashi.Data.DTOs.Site.Admin.Users
{
    public class UserForListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public ICollection<PhotoForUserDetailedDto> Photos { get; set; }
        public ICollection<PrescriptionForUserDetailedDto> Prescriptions { get; set; }
    }
}
