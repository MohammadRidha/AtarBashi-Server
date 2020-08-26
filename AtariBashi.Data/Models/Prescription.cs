using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtarBashi.Data.Models
{
    public class Prescription : BaseEntity<string>
    {
        public Prescription()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }

        [Required]
        [MaxLength(100, ErrorMessage = "{0}نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Required]
        public string DoctorsPrescribe { get; set; }


        #region relations
        public string UserId { get; set; }
        public User User { get; set; }

        #endregion
    }
}
