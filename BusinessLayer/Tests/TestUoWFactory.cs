using ClubIS.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClubIS.BusinessLayer.Tests
{
    public static class TestUoWFactory
    {
        public static UnitOfWork Create()
        {
            DbContextOptionsBuilder<DataContext> builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            DbContextOptions<DataContext> dbContextOptions = builder.Options;
            DataContext context = new DataContext(dbContextOptions);
            // Delete existing db before creating a new one
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return new UnitOfWork(context);
        }
    }
}
