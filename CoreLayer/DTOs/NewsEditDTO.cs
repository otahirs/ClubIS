using System;
using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.DTOs
{
    public class NewsEditDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(2048)]
        public string Text { get; set; }
    }
}