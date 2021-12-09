using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class SupervisionRepository : Repository<Supervision>, ISupervisionRepository
    {
        public SupervisionRepository(DataContext context) : base(context)
        {
        }
    }
}