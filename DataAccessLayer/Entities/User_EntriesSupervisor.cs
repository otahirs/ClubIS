﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class User_EntriesSupervisor : TrackModifiedDateEntity
    {
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public int EntriesSupervisorId { get; set; }

        [ForeignKey(nameof(EntriesSupervisorId))]
        public virtual User EntriesSupervisor { get; set; }
    }
}