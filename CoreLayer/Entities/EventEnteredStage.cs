using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClubIS.CoreLayer.Entities
{
    public class EventEnteredStage
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
    }
}
