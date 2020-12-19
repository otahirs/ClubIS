using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.CoreLayer.DTOs
{
    public class EventEntryBasicInfoDTO
    {
        public int Id {get; set; }
        public int UserId { get; set; }
        public int EventId {get; set;}
        public string Class { get; set; }

    }
}
