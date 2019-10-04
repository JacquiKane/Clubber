using Clubber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Clubber.Models
{

    public class ClubDetail
    {
        public int ClubId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DayOfWeek MeetingDay { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime MeetingTime { get; set; }
        [ForeignKey("Sponsor")]
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }
        [Required]
        [Display(Name = "Club Category")]
        public Club_Category ClubType { get; set; }
    }
}