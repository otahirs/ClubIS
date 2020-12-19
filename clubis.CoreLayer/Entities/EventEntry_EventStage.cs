using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace clubIS.CoreLayer.Entities
{
    class EventEntry_EventStage
    {
        public int EntryId { get; set; }

        [ForeignKey(nameof(EntryId))]
        public EventEntry Entry { get; set; }
        public int StageId { get; set; }

        [ForeignKey(nameof(StageId))]
        public EventStage Stage { get; set; }
    }
}
