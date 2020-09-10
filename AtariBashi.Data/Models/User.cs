using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtarBashi.Data.Models
{
    public class User : BaseEntity<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }

        [Required]
        [StringLength(0, MinimumLength = 100)]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(0, MinimumLength = 100)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(0, MinimumLength = 500)]
        public string Address { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastActive { get; set; }

        [StringLength(0, MinimumLength = 100)]
        public string City { get; set; }

        [Required]
        public bool IsAcive { get; set; }
        [Required]
        public bool Status { get; set; }



        #region relations
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        #endregion

    }
}
