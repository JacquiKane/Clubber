using Clubber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Clubber.Models
{

    public class ClubCreate
    {
   //     public int ClubId { get; set; }

   //     public Guid OwnerId { get; set; }

 
        [Required]
        public string Title { get; set; }

        [Display(Name = "Club Category")]
        public Club_Category ClubType { get; set; }

        public DayOfWeek MeetingDay { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Time { get; set; }



        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [ForeignKey("Sponsor")]
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }

    }
}