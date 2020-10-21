using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class Event_User : TrackModifiedDateEntity
    {
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
        [MaxLength(10)]
        public string Class { get; set; }
        public bool? HasClubAccommodation { get; set; }
        public bool? HasClubTransport { get; set; }
        [MaxLength(255)]
        public string NoteForClub { get; set; }
        [MaxLength(255)]
        public string NoteForOrganisator { get; set; }

    }
}
