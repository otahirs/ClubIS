using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.CoreLayer.Entities;

namespace clubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface INewsRepository : IRepository<News>
    {
        Task<IEnumerable<News>> GetAllIncludeUser();
    }
}
