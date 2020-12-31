using System;
using System.Collections.Generic;
using System.Text;

namespace ClubIS.CoreLayer.DTOs
{
    public class FinanceStatementDTO
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public int CreditBalance { get; set; }
        public List<PaymentListDTO> Payments { get; set; }
    }
}
