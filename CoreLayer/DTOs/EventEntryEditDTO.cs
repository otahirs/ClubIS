using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventEntryEditDTO
    {
        public int Id {get; set; }
        public int UserId { get; set; }
        public int EventId {get; set;}
        public string Class { get; set; }
        public bool HasClubAccommodation { get; set; }
        public bool HasClubTransport { get; set; }
        public string NoteForClub { get; set; }
        public string NoteForOrganizators { get; set; }
        public int SiCardNumber { get; set; }
        public IEnumerable<EventStageDTO> EnteredStages { get; set; }

    }
}
