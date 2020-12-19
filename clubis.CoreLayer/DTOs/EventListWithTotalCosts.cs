using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.CoreLayer.DTOs
{
    public class EventListWithTotalCostsDTO
    {
        public EventListDTO Event { get; set; }
        public int TotalCosts { get; set; } 
    }
}
 