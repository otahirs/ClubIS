using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.UoWandRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IEventsRepository Events { get; }
        void Commit();
    }
}
