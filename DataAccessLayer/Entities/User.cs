using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{

    public class User : BaseEntity
    {
        public int? BillingUserId { get; set; }

        [ForeignKey(nameof(BillingUserId))]
        public virtual User BillingUser { get; set; }
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }

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
        public int? SiCardNumber { get; set; }
        [MaxLength(4)]
        public int RegistrationNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(50)]
        public string Nationality { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(25)]
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Licence Licence { get; set; }
        public AccountState AccountState { get; set; }
        public DateTime Created { get; set; }
        public Role Roles { get; set; }
        public int? CreditBalance { get; set; }

    }
}
