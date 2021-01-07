using System;
using System.Collections.Generic;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int AccountId { get; set; }
        public string RegistrationNumber { get; set; }
        public ISet<SiCardDTO> SiCards { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Licence Licence { get; set; }
        public MemberFeeDTO MemberFee { get; set; }
        public AccountState AccountState { get; set; }
    }
}
