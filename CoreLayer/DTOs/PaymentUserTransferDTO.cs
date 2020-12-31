using ClubIS.CoreLayer.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.DTOs
{
    public class PaymentUserTransferDTO
    {
        [Required]
        public int SourceUserId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int RecipientUserId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CreditAmount { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
