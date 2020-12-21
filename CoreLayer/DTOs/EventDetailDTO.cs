using System;
using System.Collections.Generic;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventDetailDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Organizer { get; set; }
        public EventType EventType { get; set; }
        public string Link { get; set; }
        public ICollection<DateTime> Deadlines { get; set; }
        public string Leader { get; set; }
        public ISet<string> ClassOptions { get; set; }
        public EventState EventState { get; set; }
        public EventProperty EventProperties { get; set; }
        public string Note { get; set; }
        public ISet<EventStageDTO> EventStages { get; set; }
    }
}
