using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.BusinessLayer.DTOs
{
    public class PaymentEntryListDTO
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public int CreditAmount { get; set; }
        public string Message { get; set; }
    }
}
