using System;
using System.Collections.Generic;
using System.Text;
using clubIS.CoreLayer.Entities;
using clubIS.CoreLayer.Enums;

namespace clubIS.CoreLayer.DTOs
{
    public class EventListDTO
    {
        public int Id { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public EventType EventType { get; set; }
        public ICollection<EventDeadline> Deadlines { get; set; }
    }
}
