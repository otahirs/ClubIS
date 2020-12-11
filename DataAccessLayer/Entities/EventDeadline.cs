using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace clubIS.DataAccessLayer.Entities
{
    public class EventDeadline
    {
        [Key]
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public int EventId { get; set; }
    }
}
