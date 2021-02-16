using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Place { get; set; }

        [MaxLength(50)]
        public string Organizer { get; set; }

        public ClubEventOption AccommodationOption { get; set; }
        public ClubEventOption TransportOption { get; set; }

        [MaxLength(50)]
        public string Link { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual ICollection<EventDeadline> Deadlines { get; set; }
        public virtual ISet<EventClassOption> ClassOptions { get; set; }
        public string Leader { get; set; }
        public EventType EventType { get; set; }
        public EventState EventState { get; set; }
        public EventProperty EventProperties { get; set; }
        public virtual ISet<EventStage> EventStages { get; set; }
        public EntriesExport Entries { get; set; }
    }
}