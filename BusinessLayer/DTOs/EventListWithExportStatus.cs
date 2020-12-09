using System;
using System.Collections.Generic;
using System.Text;
using clubIS.DataAccessLayer.Entities;
using clubIS.DataAccessLayer.Enums;

namespace clubIS.BusinessLayer.DTOs
{
    public class EventListWithExportStatusDTO
    {
        public EventListDTO Event { get; set; }
        public int ExportStatus { get; set; }
    }
}
