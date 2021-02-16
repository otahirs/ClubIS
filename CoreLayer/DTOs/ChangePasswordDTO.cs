using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.DTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        public int EditedUserId { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}