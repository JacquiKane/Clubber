using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Models
{
    public class StudentProfileCreate
    {
        public Guid UserId { get; set; }
        public int StudentId { get; set; }
        public string UserName { get; set; }
        public string Hobby1 { get; set; }
        public string Hobby2 { get; set; }
        public string Hobby3 { get; set; }
    }
}
