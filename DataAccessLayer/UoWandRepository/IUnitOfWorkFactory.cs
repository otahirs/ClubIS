using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.UoWandRepository
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
