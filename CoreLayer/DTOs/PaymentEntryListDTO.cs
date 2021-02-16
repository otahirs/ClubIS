using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.DTOs
{
    public class PaymentEntryListDTO
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int PaymentId { get; set; }

        [Range(1, int.MaxValue)]
        public int? CreditAmount { get; set; }

        public string Message { get; set; }
    }
}