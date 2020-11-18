using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using clubIS.DataAccessLayer.Entities;

namespace clubIS.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventEntry> EventEntries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<MemberFee> MemberFees { get; set; }
        public DbSet<FinanceAccount> FinanceAccounts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For dev purposes
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=clubIS");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.ClassOptions)
                .HasConversion(
                    o => JsonConvert.SerializeObject(o),
                    o => JsonConvert.DeserializeObject<ISet<string>>(o));

            modelBuilder.Entity<User_EntriesSupervisor>()
                .HasKey(us => new { us.UserId, us.EntriesSupervisorId });

            modelBuilder.Entity<User_EntriesSupervisor>()
                .HasOne(i => i.User)
                .WithMany(i => i.EntriesSupervisors)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User_EntriesSupervisor>()
                .HasOne(i => i.EntriesSupervisor)
                .WithMany(i => i.EntriesSupervisedUsers)
                .HasForeignKey(i => i.EntriesSupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
