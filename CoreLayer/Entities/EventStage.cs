﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubIS.CoreLayer.Entities
{
    public class EventStage
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        [MaxLength(50)]
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public virtual ISet<EventEntry_EventStage> StageEntries { get; set; }
    }
}
