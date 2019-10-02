using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Models
{
    public class SponsorListItem
    {
        public int SponsorId { get; set; }
        [Display(Name = "Background Check On File")]
        public bool BackGroundCheck { get; set; }
        [Display(Name = "Name")]
        public String FirstName { get; set; }
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
