using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.DTOs
{
    public class ChangeLoginDTO
    {
        [Required]
        public int EditedUserId { get; set; }
        [Required]
        public string NewUserName { get; set; }

        [Required]
        public string AprovalPassword { get; set; }
    }
}
