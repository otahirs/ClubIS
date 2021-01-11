using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }
        public int AccountId { get; set; }
        [Required]
        [MaxLength(7)]
        public string RegistrationNumber { get; set; }
        public ISet<SiCardDTO> SiCards { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(50)]
        public string Nationality { get; set; }
        public Address Address { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(25)]
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Licence Licence { get; set; }
        public MemberFeeDTO MemberFee { get; set; }
        public AccountState AccountState { get; set; }
    }
}
