using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.Entities
{

    public class User
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public FinanceAccount Account { get; set; }
        public int? BillingAccountId { get; set; }

        [ForeignKey(nameof(BillingAccountId))]
        public FinanceAccount BillingAccount { get; set; }
        public ISet<User_EntriesSupervisor> EntriesSupervisors { get; set; }
        public ISet<User_EntriesSupervisor> EntriesSupervisedUsers { get; set; }

        public int? MemberFeeId { get; set; }
        [ForeignKey(nameof(MemberFeeId))]
        public MemberFee MemberFee { get; set; }
        public Address Address { get; set; }

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
        public ISet<SiCard> SiCards { get; set; }


        [MaxLength(7)]
        public string RegistrationNumber { get; set; }
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
        public Role Roles { get; set; }
    }
}
