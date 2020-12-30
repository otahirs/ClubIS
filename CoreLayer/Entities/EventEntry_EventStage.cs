using System.ComponentModel.DataAnnotations.Schema;

namespace ClubIS.CoreLayer.Entities
{
    public class EventEntry_EventStage
    {
        public int EventEntryId { get; set; }

        [ForeignKey(nameof(EventEntryId))]
        public virtual EventEntry Entry { get; set; }
        public int EventStageId { get; set; }

        [ForeignKey(nameof(EventStageId))]
        public virtual EventStage Stage { get; set; }
    }
}
