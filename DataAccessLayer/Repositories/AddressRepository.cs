using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}
