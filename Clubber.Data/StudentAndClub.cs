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
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Club")]
        public int ClubID {get; set;}
        public virtual Club Club { get; set; }
    }
}
