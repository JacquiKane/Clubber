using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public String StudentFirstName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public String StudentLastName { get; set; }
        public String FullName {
            get {
                return StudentFirstName + " " + StudentLastName;
            }
        }
        public int Age { get; set; }
        [Display(Name="Parent Name")]
        public string ParentFirstName { get; set; } 
        [Display(Name="Surname")]
        public string ParentLastName { get; set; }
        [Display(Name="E-Mail")]
        public string ContactEMail { get; set; }


    }
}
