using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class EventEntryEditDTO
    {
        
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Class { get; set; }
        [Required]
        public bool HasClubAccommodation { get; set; }
        [Required]
        public bool HasClubTransport { get; set; }
        public string NoteForClub { get; set; }
        public string NoteForOrganizators { get; set; }
        [Required]
        public int SiCardNumber { get; set; }
        [Required]
        public ISet<EventEnteredStage> EnteredStages { get; set; }
        public EntryStatus Status { get; set; }

    }
}
