using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class Payment : BaseEntity
    {
        public int? ExecutorId { get; set; }

        [ForeignKey(nameof(ExecutorId))]
        public virtual User Executor { get; set; }
        public int? AccountOwnerId { get; set; }

        [ForeignKey(nameof(AccountOwnerId))]
        public virtual User AccountOwner { get; set; }
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
