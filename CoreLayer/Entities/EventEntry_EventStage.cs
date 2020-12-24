using System.ComponentModel.DataAnnotations.Schema;

namespace ClubIS.CoreLayer.Entities
{
    class EventEntry_EventStage
    {
        public int EntryId { get; set; }

        [ForeignKey(nameof(EntryId))]
        public virtual EventEntry Entry { get; set; }
        public int StageId { get; set; }

        [ForeignKey(nameof(StageId))]
        public virtual EventStage Stage { get; set; }
    }
}
