using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Models
{
    class StudentJoinClubView
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public String StudentFirstName { get; set; }
        [Required]
        public String StudentLastName { get; set; }
      
        public int Age { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string ContactEMail { get; set; }
    }
}
