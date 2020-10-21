using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class UserActionsLog
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public DateTime Timestamp { get; set; }
        [MaxLength(255)]
        public string Message { get; set; }
    }
}
