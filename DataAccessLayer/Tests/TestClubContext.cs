using System;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Tests
{
    internal class TestClubContext : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }
    }
}