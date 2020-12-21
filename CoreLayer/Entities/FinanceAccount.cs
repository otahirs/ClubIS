using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.Entities
{
    public class FinanceAccount
    {
        [Key]
        public int Id { get; set; }
        public int CreditBalance { get; set; }
        public User Owner { get; set; }
    }
}
