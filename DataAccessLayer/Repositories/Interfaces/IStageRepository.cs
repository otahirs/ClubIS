using ClubIS.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IStageRepository : IRepository<EventStage>
    {
        Task<IEnumerable<EventStage>> GetAllById(IEnumerable<int> ids);
    }
}
