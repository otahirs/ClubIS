using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.CoreLayer.DTOs
{
    public class EventListWithUserEntryDTO
    {
        public EventListDTO Event { get; set; }
        public EventEntryBasicInfoDTO EntryInfo { get; set; }
    }
}
