using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Models
{
    public class SponsorListItem
    {
        public int SponsorId { get; set; }
        public bool BackGroundCheck { get; set; }
        public String FirstName { get; set; }
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
