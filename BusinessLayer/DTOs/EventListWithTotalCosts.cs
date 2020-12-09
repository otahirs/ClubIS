using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.BusinessLayer.DTOs
{
    public class EventListWithTotalCostsDTO
    {
        public EventListDTO Event { get; set; }
        public int TotalCosts { get; set; } 
    }
}
 