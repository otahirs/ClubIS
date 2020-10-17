using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{

    public class User : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Username { get; set; }
        [Required]
        [MaxLength(33)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }
        [MaxLength(9)]
        public int? SiNumber { get; set; }
        [MaxLength(4)]
        public int RegNumber { get; set; }
        [MaxLength(20)]
        public string club { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(50)]
        public string StreetAndNumber { get; set; }
        [MaxLength(25)]
        public string City { get; set; }
        [MaxLength(6)]
        public string Psc { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(25)]
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Licence Licence { get; set; }
        public AcountState AcountState { get; set; }
        public MemberFeeType MemberFeeType { get; set; }
        public DateTime Created { get; set; }
        public Roles Roles { get; set; }

    }
}
