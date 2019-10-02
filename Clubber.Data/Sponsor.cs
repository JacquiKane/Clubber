﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Data
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }
        [Required]
        [Display(Name="Background Check On File")]
        public bool BackGroundCheck { get; set; }
        [Required]
        [Display(Name = "Name")]
        public String FirstName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public String LastName { get; set; }
        public String FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}

