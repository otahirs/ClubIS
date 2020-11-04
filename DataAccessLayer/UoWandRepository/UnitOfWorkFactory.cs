using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.UoWandRepository
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            var context = new DataContext();
            return new UnitOfWork(
                context,
                new EventsRepository(context)
            );
        }
    }
}
