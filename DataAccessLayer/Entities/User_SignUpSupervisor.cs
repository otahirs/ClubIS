using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class User_SignUpSupervisor : TrackModifiedDateEntity
    {
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public int? SignUpSupervisorId { get; set; }

        [ForeignKey(nameof(SignUpSupervisorId))]
        public virtual User SignUpSupervisor { get; set; }
    }
}
