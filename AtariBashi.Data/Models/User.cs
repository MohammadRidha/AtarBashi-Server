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
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
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
