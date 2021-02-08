using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class StageRepository : Repository<EventStage>, IStageRepository
    {
        public StageRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<EventStage>> GetAllById(IEnumerable<int> ids)
        {
            return await _entities.Where(s => ids.Contains(s.Id)).ToListAsync();
        }


    }
}
