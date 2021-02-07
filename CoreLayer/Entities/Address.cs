using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [MaxLength(50)]
        public string StreetAndNumber { get; set; }
        [MaxLength(25)]
        public string City { get; set; }
        [MaxLength(6)]
        public string PostalCode { get; set; }
    }
}
