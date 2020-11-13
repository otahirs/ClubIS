﻿using System;
using System.Collections.Generic;
using System.Text;
using clubIS.DataAccessLayer.Entities;
using DataAccessLayer.Enums;

namespace clubIS.DataAccessLayer.DTOs
{
    class EventListDTO
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Organizer { get; set; }
        public EventType EventType { get; set; }
        public string Link { get; set; }
        public ICollection<EventDeadline> Deadlines { get; set; }
        public string Leader { get; set; }
        public string Class { get; set; }
        public EventState EventState { get; set; }
        public EventProperty EventProperties { get; set; }
    }
}
