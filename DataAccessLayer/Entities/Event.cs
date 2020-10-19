using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataAccessLayer.Enums;


namespace DataAccessLayer.Entities
{
    public class Event
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Place { get; set; }
        [MaxLength(50)]
        public ICollection<ClubEventOptions> AccommodationOptions { get; set; }
        public ICollection<ClubEventOptions> TransportOptions { get; set; }

        [MaxLength(50)]
        public string Link { get; set; }
        [MaxLength(255)]
        public string Note { get; set; }
        public ICollection<DateTime> Deadlines { get; set; }
        public ICollection<string> ClassesOptions { get; set; }
        public string Leader { get; set; }
        public EventType EventType { get; set; }
        public EventState EventState { get; set; }
        public EventProperties EventProperties { get; set; }
    }
}
