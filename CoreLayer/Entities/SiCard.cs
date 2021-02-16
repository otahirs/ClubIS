using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubIS.CoreLayer.Entities
{
    public class SiCard
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public int Number { get; set; }

        public bool IsDefault { get; set; }
    }
}