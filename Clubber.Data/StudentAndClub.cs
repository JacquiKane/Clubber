using Clubber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Models
{
    public class StudentAndClub
    {
        [Key]
        public int RelationshipId { get; set; }
        public int StudentID { get; set; }
        public int ClubID {get; set;}
    }
}
