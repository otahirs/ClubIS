using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace clubIS.DataAccessLayer.Entities
{
    public class EventStage
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }
        [MaxLength(50)]
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
