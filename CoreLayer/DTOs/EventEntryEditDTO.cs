using ClubIS.CoreLayer.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventEntryEditDTO
    {

        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public bool HasClubAccommodation { get; set; }
        [Required]
        public bool HasClubTransport { get; set; }
        public string NoteForClub { get; set; }
        public string NoteForOrganisator { get; set; }
        public int? SiCardNumber { get; set; }
        [Required]
        public ISet<EventStageDTO> EnteredStages { get; set; }
        public EntryStatus Status { get; set; }

    }
}
