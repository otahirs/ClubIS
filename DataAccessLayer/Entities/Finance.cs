using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{

    public class Finance : BaseEntity
    {
        public int? ExecutorId { get; set; }

        [ForeignKey(nameof(ExecutorId))]
        public virtual User Executor { get; set; }
        public int? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner { get; set; }
        public int? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
        public DateTime Timestamp { get; set; }
        public int Amount { get; set; }
        [MaxLength(255)]
        public string Message { get; set; }
        public FinanceState FinanceState { get; set; }
        [MaxLength(255)]
        public string StornoNote { get; set; }
    }
}
