using System;
using clubIS.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace clubIS.BusinessLayer.Tests
{
    public static class TestUoWFactory
    {
        public static UnitOfWork Create()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContextOptions = builder.Options;
            var context = new DataContext(dbContextOptions);
            // Delete existing db before creating a new one
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return new UnitOfWork(context);
        }
    }
}
