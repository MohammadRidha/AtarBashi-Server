﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtarBashi.Data.Models
{
    public class Photo : BaseEntity<string>
    {
        public Photo()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }

        [Required]
        [StringLength(0, MinimumLength = 1000)]
        public string Url { get; set; }

        [StringLength(0, MinimumLength = 500)]
        public string Description { get; set;
        }
        [StringLength(0, MinimumLength = 500)]
        public string Alt { get; set; }
        [Required]
        public bool IsMain { get; set; }


        #region relations
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        #endregion
    }
}
