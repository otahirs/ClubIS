using clubIS.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface INewsRepository : IRepository<News>
    {
        Task<IEnumerable<News>> GetAllIncludeUser();
    }
}
