using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Deadline
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } 
    }
}
