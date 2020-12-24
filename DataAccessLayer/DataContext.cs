using System.Collections.Generic;
using ClubIS.CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClubIS.DataAccessLayer
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
            // enable lazy loading
            optionsBuilder.UseLazyLoadingProxies();
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

            modelBuilder.Entity<FinanceAccount>()
                .HasOne(a => a.Owner)
                .WithOne(u => u.Account)
                .HasForeignKey<User>(u => u.AccountId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.BillingAccount)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
