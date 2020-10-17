using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class SystemLog : BaseEntity
    {
        public DateTime Timestamp { get; set; }
        [MaxLength(255)]
        public string Message { get; set; }
    }
}
