using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace clubIS.DataAccessLayer.Tests
{
    class TestClubContext : ClubContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }
    }
}
