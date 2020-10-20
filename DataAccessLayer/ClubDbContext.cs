using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

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
    }
}
