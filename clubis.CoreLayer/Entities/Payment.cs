﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using clubIS.CoreLayer.Enums;

namespace clubIS.CoreLayer.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int? ExecutorId { get; set; }

        [ForeignKey(nameof(ExecutorId))]
        public User Executor { get; set; }
        public int SourceAccountId { get; set; }

        [ForeignKey(nameof(SourceAccountId))]
        public FinanceAccount SourceAccount { get; set; }
        public int? TargetAccountId { get; set; }

        [ForeignKey(nameof(TargetAccountId))]
        public FinanceAccount TargetAccount { get; set; }
        public int? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }
        public int CreditAmount { get; set; }
        [MaxLength(255)]
        public string Message { get; set; }
        public PaymentState PaymentState { get; set; }
        [MaxLength(255)]
        public string StornoNote { get; set; }
    }
}