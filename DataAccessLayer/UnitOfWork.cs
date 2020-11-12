using clubIS.DataAccessLayer.Repositories;
using clubIS.DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Events = new EventRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        public IEventRepository Events { get; private set; }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
