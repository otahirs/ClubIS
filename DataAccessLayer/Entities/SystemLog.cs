using System;
using DataAccessLayer.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class SystemLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        [MaxLength(255)]
        public LogSeverity Severity { get; set; }
        public string Message { get; set; }
    }
}
