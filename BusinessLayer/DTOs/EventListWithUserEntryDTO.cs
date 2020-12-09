using System;
using System.Collections.Generic;
using System.Text;
using clubIS.DataAccessLayer.Entities;
using clubIS.DataAccessLayer.Enums;

namespace clubIS.BusinessLayer.DTOs
{
    public class EventListWithUserEntryDTO
    {
        public EventListDTO Event { get; set; }
        public EventEntryBasicInfoDTO EntryInfo { get; set; }
    }
}
