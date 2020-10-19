using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class MemberFee : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public int Amount { get; set; }
        public MemberFeeType MemberFeeType { get; set; }
    }
}
