using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Models
{
    public class JoinClub
    {
        [Required]
        public int StudentId { get; set; }
      
        public int ClubId { get; set; }

        public string ClubTitle { get; set; }
    }
}
