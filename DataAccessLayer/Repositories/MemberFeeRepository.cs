using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class MemberFeeRepository : Repository<MemberFee>, IMemberFeeRepository
    {
        public MemberFeeRepository(DataContext context) : base(context)
        {
        }
    }
}
