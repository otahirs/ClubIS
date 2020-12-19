using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace clubIS.CoreLayer.Entities
{
    public class EventEntry
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }
        [MaxLength(10)]
        public string Class { get; set; }
        public bool HasClubAccommodation { get; set; }
        public bool HasClubTransport { get; set; }
        [MaxLength(255)]
        public string NoteForClub { get; set; }
        [MaxLength(255)]
        public string NoteForOrganisator { get; set; }
        public int? SiCardNumber { get; set; }
        public ISet<EventStage> EnteredStages { get; set; }

    }
}
