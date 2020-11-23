using System;
using System.Collections.Generic;
using System.Text;
using clubIS.DataAccessLayer.Enums;

namespace clubIS.BusinessLayer.DTOs
{
    public class PaymentListDTO
    {
        public int Id { get; set; }
        public string ExecutorName { get; set; }
        public string SourceAccountName { get; set; }
        public string TargetAccountName { get; set; }
        public string EventName { get; set; }
        public int CreditAmount { get; set; }
        public string Message { get; set; }
        public PaymentState PaymentState { get; set; }
        public string StornoNote { get; set; }
    }
}
