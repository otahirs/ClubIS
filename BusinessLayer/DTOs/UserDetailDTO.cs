using clubIS.DataAccessLayer.Entities;
using clubIS.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.BusinessLayer.DTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public ISet<SiCard> SiCards { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Licence Licence { get; set; }
    }
}
