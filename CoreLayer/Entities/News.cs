using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubIS.CoreLayer.Entities
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(2048)]
        public string Text { get; set; }
    }
}