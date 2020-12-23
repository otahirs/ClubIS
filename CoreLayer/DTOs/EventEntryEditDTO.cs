using System;
using System.Collections.Generic;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventEntryEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EventDeadline> Deadlines { get; set; }
        public ISet<string> ClassOptions { get; set; }
    }
}
