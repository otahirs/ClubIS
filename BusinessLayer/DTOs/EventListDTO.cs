using System;
using System.Collections.Generic;
using System.Text;
using clubIS.DataAccessLayer.Entities;
using clubIS.DataAccessLayer.Enums;

namespace clubIS.BusinessLayer.DTOs
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
