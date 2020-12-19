using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.CoreLayer.DTOs
{
    public class EventListWithExportStatusDTO
    {
        public EventListDTO Event { get; set; }
        public int ExportStatus { get; set; }
    }
}
