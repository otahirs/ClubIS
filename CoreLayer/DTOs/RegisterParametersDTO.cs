using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClubIS.CoreLayer.DTOs
{
    public class RegisterParametersDTO
    {
        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(7)]
        public string RegistrationNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
