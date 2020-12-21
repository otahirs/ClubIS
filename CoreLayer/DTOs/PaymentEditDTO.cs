using ClubIS.CoreLayer.Enums;
using System;

namespace ClubIS.CoreLayer.DTOs
{
    public class PaymentEditDTO
    {
        public int ExecutorId { get; set; }
        public int? SourceAccountId { get; set; }
        public int? RecipientAccountId { get; set; }
        public int? SourceUserId { get; set; }
        public int? RecipientUserId { get; set; }
        public int? EventId { get; set; }
        public int CreditAmount { get; set; }
        public string Message { get; set; }
        public PaymentState PaymentState { get; set; }
        public DateTime Date { get; set; }

    }
}
