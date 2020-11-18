using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.BusinessLayer.DTOs
{
    public class SendPaymentDTO
    {
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public int CreditAmount { get; set; }
        public string Message { get; set; }
    }
}
