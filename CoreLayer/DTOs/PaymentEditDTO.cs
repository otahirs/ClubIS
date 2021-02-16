using System;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class PaymentEditDTO
    {
        public int Id { get; set; }
        public int ExecutorId { get; set; }
        public int? SourceAccountId { get; set; }
        public int? RecipientAccountId { get; set; }
        public int? EventId { get; set; }
        public int CreditAmount { get; set; }
        public string Message { get; set; }
        public PaymentState PaymentState { get; set; }
        public DateTime Date { get; set; }
    }
}