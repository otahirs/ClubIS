using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class User_MemberFee
    {
        public int MemberFeeId { get; set; }

        [ForeignKey(nameof(MemberFeeId))]
        public virtual MemberFee MemberFee { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}

