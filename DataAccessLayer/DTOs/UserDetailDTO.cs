using clubIS.DataAccessLayer.Entities;
using DataAccessLayer.Entities;
using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.DTOs
{
    class UserDetailDTO
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public ISet<SiCard> SiCards { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Licence Licence { get; set; }
    }
}
