using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventEntryListDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public int SiCardNumber { get; set; }
        public string Class { get; set; }
        public bool HasClubAccommodation { get; set; }
        public bool HasClubTransport { get; set; }
        public string NoteForClub { get; set; }
        public string NoteForOrganizators { get; set; }
        public ISet<EventStageDTO> EnteredStages { get; set; }

    }
}
