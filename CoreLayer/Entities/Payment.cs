using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public int? ExecutorId { get; set; }

        [ForeignKey(nameof(ExecutorId))]
        public virtual User Executor { get; set; }

        public int? SourceAccountId { get; set; }

        [ForeignKey(nameof(SourceAccountId))]
        public virtual FinanceAccount SourceAccount { get; set; }

        public int? RecipientAccountId { get; set; }

        [ForeignKey(nameof(RecipientAccountId))]
        public virtual FinanceAccount RecipientAccount { get; set; }

        public int? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }

        public DateTime Date { get; set; }
        public int CreditAmount { get; set; }

        [MaxLength(255)]
        public string Message { get; set; }

        public PaymentState PaymentState { get; set; }

        [MaxLength(255)]
        public string StornoNote { get; set; }
    }
}