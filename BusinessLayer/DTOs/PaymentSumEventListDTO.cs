using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.BusinessLayer.DTOs
{
    public class PaymentSumEventListDTO
    {
        public EventListDTO EventList { get; set; }
        public int TotalCosts { get; set; }
    }
}
 