using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClubIS.CoreLayer.Entities
{
    public class EventClassOption
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
    }
}
