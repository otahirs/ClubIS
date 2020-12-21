using System.ComponentModel.DataAnnotations;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.Entities
{
    public class MemberFee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public int Amount { get; set; }
        public MemberFeeType MemberFeeType { get; set; }
    }
}
