using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class Signup
    {
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public int? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }

        public DateTime Timestamp { get; set; }
        public Class Class { get; set; }
        public Accommodation Accommodation { get; set; }
        public Transport Transport { get; set; }
        [MaxLength(255)]
        public string NoteForClub { get; set; }
        [MaxLength(255)]
        public string NoteforOrganizator { get; set; }

    }
}
