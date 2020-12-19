using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace clubIS.CoreLayer.Entities
{
    public class User_EntriesSupervisor
    {
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int EntriesSupervisorId { get; set; }

        [ForeignKey(nameof(EntriesSupervisorId))]
        public User EntriesSupervisor { get; set; }
    }
}
