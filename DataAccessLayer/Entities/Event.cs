using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class Event
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Place { get; set; }
        [MaxLength(50)]
        public string OrgannizingClub { get; set; }
        public RaceType Type { get; set; }
        public Ranking Ranking { get; set; }
        public Accommodation Accommodation { get; set; }
        public Transport Transport { get; set; }
        [MaxLength(50)]
        public string Link { get; set; }
        [MaxLength(255)]
        public string Note { get; set; }
        public ICollection<DateTime> Deadlines { get; set; }
        public ICollection<Class> Classes { get; set; }
        public string Leader { get; set; }
        public EventStatus Status { get; set; }
    }
}
