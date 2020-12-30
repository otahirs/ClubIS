using System;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventStageDTO
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; } = false;
    }
}
