﻿using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.BusinessLayer.DTOs
{
    public class EventStageDTO
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
