using System;
using System.Collections.Generic;
using System.Text;
using clubIS.CoreLayer.Entities;
using clubIS.CoreLayer.Enums;

namespace clubIS.CoreLayer.DTOs
{
    public class UserEditDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public ISet<SiCard> SiCards { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Licence Licence { get; set; }
    }
}
