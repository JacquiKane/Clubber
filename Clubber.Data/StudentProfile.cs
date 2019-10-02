using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Data
{
    public class StudentProfile
    {
        [Key]
        public int ProfileId { get; set; }
        public Guid UserId { get; set; }
        public int StudentId {get; set;}
        public string Hobby1 { get; set; }
        public string Hobby2 { get; set; }
        public string Hobby3 { get; set; }
    }
}
