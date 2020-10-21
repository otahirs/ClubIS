using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace DataAccessLayer
{
    class ClubDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Event_User> SignUps { get; set; }
        public DbSet<User_SignUpSupervisor> SignUpSupervisors { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<MemberFee> MemberFees { get; set; }
        public DbSet<User_MemberFee> SelectedMemberFee { get; set; }
        public DbSet<UserActionsLog> UserActionsLogs { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }



        private string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=clubIS";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event_User>()
                .HasKey(eu => new { eu.EventId, eu.UserId });
            modelBuilder.Entity<User_SignUpSupervisor>()
                .HasKey(us => new { us.UserId, us.SignUpSupervisorId });
            modelBuilder.Entity<User_MemberFee>()
                .HasKey(um => new { um.UserId, um.MemberFeeId });
        }


        // automatically create/update CreatedDate and UpdatedDate properties
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
                                                         CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedDate / CreatedDate appropriately
                if (entry.Entity is TrackModifiedDateEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedDate = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedDate").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedDate = utcNow;
                            trackable.UpdatedDate = utcNow;
                            break;
                    }
                }
            }
        }
    }
}
