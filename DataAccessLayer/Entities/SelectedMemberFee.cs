using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class SelectedMemberFee
    {
        public int FeeId { get; set; }

        [ForeignKey(nameof(FeeId))]
        public virtual MemberFee Fee { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}

