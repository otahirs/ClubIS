using System;
using Microsoft.EntityFrameworkCore;

namespace clubIS.DataAccessLayer.Tests
{
    class TestClubContext : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }
    }
}
