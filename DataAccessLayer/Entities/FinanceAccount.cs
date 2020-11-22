using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace clubIS.DataAccessLayer.Entities
{
    public class FinanceAccount
    {
        [Key]
        public int Id { get; set; }
        public int CreditBalance { get; set; }
        public User Owner { get; set; }
    }
}
