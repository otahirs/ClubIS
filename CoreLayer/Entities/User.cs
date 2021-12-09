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
        public virtual FinanceAccount Account { get; set; }

        public virtual ICollection<Supervision> SupervisedBy { get; set; }
        public virtual ICollection<Supervision> UnderSupervision { get; set; }

        public int? MemberFeeId { get; set; }

        [ForeignKey(nameof(MemberFeeId))]
        public virtual MemberFee MemberFee { get; set; }

        public virtual Address Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        public virtual ISet<SiCard> SiCards { get; set; }

        [Required]
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
    }
}