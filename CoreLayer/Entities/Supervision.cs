using System.ComponentModel.DataAnnotations.Schema;

namespace ClubIS.CoreLayer.Entities
{
    public class Supervision
    {
        public int SupervisorUserId { get; set; }

        [ForeignKey(nameof(SupervisorUserId))]
        public virtual User Supervisor { get; set; }
        
        public int SupervisedUserId { get; set; }

        [ForeignKey(nameof(SupervisedUserId))]
        public virtual User SupervisedUser { get; set; }

        public bool IsEntrySupervisionEnabled { get; set; }
        
        public bool IsFinanceSupervisionEnabled { get; set; }
    }
}