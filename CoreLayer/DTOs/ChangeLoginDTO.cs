using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClubIS.CoreLayer.DTOs
{
    public class ChangeLoginDTO
    {
        [Required]
        public string NewUserName { get; set; }

        [Required]
        public string AprovalPassword { get; set; }
    }
}
