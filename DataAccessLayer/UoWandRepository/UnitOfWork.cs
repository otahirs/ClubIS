using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.UoWandRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IEventsRepository Events { get; }

        public UnitOfWork(DataContext dataContext,
            IEventsRepository eventsRepository)
        {
            this._context = dataContext;
            this.Events = eventsRepository;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose();
        }
    }
}