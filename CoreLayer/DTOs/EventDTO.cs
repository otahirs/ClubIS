using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public string Organizer { get; set; }

        public EventType EventType { get; set; }
        public ClubEventOption AccommodationOption { get; set; }
        public ClubEventOption TransportOption { get; set; }
        public string Link { get; set; }
        public ICollection<EventDeadline> Deadlines { get; set; }
        public string Leader { get; set; }

        [Required]
        [MinLength(1)]
        public ISet<EventClassOption> ClassOptions { get; set; }

        public EventState EventState { get; set; }
        public EventProperty EventProperties { get; set; }
        public string Note { get; set; }
        public ISet<EventStageDTO> EventStages { get; set; }
        public EntriesExport Entries { get; set; }
    }
}