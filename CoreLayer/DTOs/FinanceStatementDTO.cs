using System.Collections.Generic;

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
