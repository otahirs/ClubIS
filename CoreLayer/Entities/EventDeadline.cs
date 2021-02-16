using System;
using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.Entities
{
    public class EventDeadline
    {
        [Key]
        public int Id { get; set; }

        public DateTime Deadline { get; set; }
        public int EventId { get; set; }
    }
}