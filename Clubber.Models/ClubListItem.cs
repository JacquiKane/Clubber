using Clubber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubber.Models
{
    public class ClubListItem
    {
        [Display(Name="Club Number")]
        public int ClubId { get; set; }
        public string Title { get; set; }
//        public int SponsorId { get; set; }
        [Display(Name = "Sponsor")]
        public string SponsorName { get; set; }
        public DayOfWeek MeetingDay { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime MeetingTime { get; set; }
    }
}
