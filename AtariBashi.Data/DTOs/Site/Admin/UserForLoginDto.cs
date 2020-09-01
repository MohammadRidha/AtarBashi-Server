using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtarBashi.Data.DTOs.Site.Admin
{
    public class UserForLoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمیباشد")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsRemember { get; set; }
    }
}
