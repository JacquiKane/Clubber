using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Data
{
    public class Club
    {
            [Key]         
            public int ClubId { get; set; }
            [Required]
            public string Title { get; set; }

            [ForeignKey("Sponsor")]
            public int SponsorId { get; set; }
            public virtual Sponsor Sponsor { get; set; }

            public DayOfWeek MeetingDay { get; set; }

            [Required]
            [DataType(DataType.Time)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
            public DateTime MeetingTime { get; set; }
    }
}
