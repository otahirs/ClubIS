using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class SignupWard
    {
        public int? WardId { get; set; }

        [ForeignKey(nameof(WardId))]
        public virtual User Ward { get; set; }
        public int? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner { get; set; }
    }
}
