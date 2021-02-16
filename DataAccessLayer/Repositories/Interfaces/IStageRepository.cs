using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;

namespace ClubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IStageRepository : IRepository<EventStage>
    {
        Task<IEnumerable<EventStage>> GetAllById(IEnumerable<int> ids);
    }
}