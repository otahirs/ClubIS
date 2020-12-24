using System.ComponentModel.DataAnnotations.Schema;

namespace ClubIS.CoreLayer.Entities
{
    public class User_EntriesSupervisor
    {
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public int EntriesSupervisorId { get; set; }

        [ForeignKey(nameof(EntriesSupervisorId))]
        public virtual User EntriesSupervisor { get; set; }
    }
}
