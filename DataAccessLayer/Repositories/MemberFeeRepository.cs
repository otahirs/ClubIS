using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class MemberFeeRepository : Repository<MemberFee>, IMemberFeeRepository
    {
        public MemberFeeRepository(DataContext context) : base(context)
        {
        }
    }
}
