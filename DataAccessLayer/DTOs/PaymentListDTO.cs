﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Enums;

namespace clubIS.DataAccessLayer.DTOs
{
    class PaymentListDTO
    {
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
