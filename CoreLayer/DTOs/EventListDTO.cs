using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using System;
using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventListDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public EventType EventType { get; set; }
        public ICollection<EventDeadline> Deadlines { get; set; }
        public EntriesExport Entries { get; set; }
        public EventState EventState { get; set; }
    }
}
