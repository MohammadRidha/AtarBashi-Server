using System;
using System.Collections.Generic;
using System.Text;

namespace AtarBashi.Data.DTOs.Site.Admin.Photos
{
    public class PhotoForUserDetailedDto
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Alt { get; set; }
        public bool IsMain { get; set; }

    }
}
