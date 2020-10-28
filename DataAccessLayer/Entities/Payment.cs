using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using clubIS.DataAccessLayer.Entities;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class Payment : TrackModifiedDateEntity
    {
        [Key]
        public int Id { get; set; }
        public int? ExecutorId { get; set; }

        [ForeignKey(nameof(ExecutorId))]
        public virtual User Executor { get; set; }
        public int SourceAccountId { get; set; }

        [ForeignKey(nameof(SourceAccountId))]
        public virtual FinanceAccount SourceAccount { get; set; }
        public int TargetAccountId { get; set; }

        [ForeignKey(nameof(TargetAccountId))]
        public virtual FinanceAccount TargetAccount { get; set; }
        public int? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
        public int CreditAmount { get; set; }
        [MaxLength(255)]
        public string Message { get; set; }
        public PaymentState PaymentState { get; set; }
        [MaxLength(255)]
        public string StornoNote { get; set; }
    }
}
