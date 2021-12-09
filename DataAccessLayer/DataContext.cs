using System;
using System.Collections.Generic;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer
{
    public class DataContext : IdentityDbContext<UserIdentity, IdentityRole<int>, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DataContext()
        {
        }

        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventEntry> EventEntries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<MemberFee> MemberFees { get; set; }
        public DbSet<FinanceAccount> FinanceAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For dev purposes
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
                optionsBuilder.EnableSensitiveDataLogging();
            }

            // enable lazy loading
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AplicationUsers => Users to avoid conflict warning DbSet Users with AspNetUsers table
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<User>()
                .Property(u => u.Id).ValueGeneratedNever();

            // modelBuilder.Entity<User>()
            //     .HasMany(left => left.SupervisedBy)
            //     .WithOne(right => right.Supervisor)
            //     .OnDelete(DeleteBehavior.Restrict);
            //
            // modelBuilder.Entity<User>()
            //     .HasMany(left => left.UnderSupervision)
            //     .WithOne(right => right.SupervisedUser)
            //     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Supervision>()
                .HasOne(p => p.Supervisor)
                .WithMany(u => u.UnderSupervision)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Supervision>()
                .HasOne(p => p.SupervisedUser)
                .WithMany(u => u.SupervisedBy)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Supervision>()
                .HasKey(p => new { p.SupervisedUserId, p.SupervisorUserId });

            modelBuilder.Entity<FinanceAccount>()
                .HasOne(a => a.Owner)
                .WithOne(u => u.Account)
                .HasForeignKey<User>(u => u.AccountId);

            modelBuilder.Entity<EventEntry>()
                .HasMany(left => left.EnteredStages)
                .WithMany(right => right.StageEntries)
                .UsingEntity<Dictionary<string, object>>("EvenEntry_EventStage", b 
                    => b.HasOne<EventStage>().WithMany().HasForeignKey("EventStageId").OnDelete(DeleteBehavior.NoAction), b 
                    => b.HasOne<EventEntry>().WithMany().HasForeignKey("EventEntryId").OnDelete(DeleteBehavior.NoAction));
            

            modelBuilder.Entity<IdentityRole<int>>()
                .HasData(
                    new IdentityRole<int>
                    {
                        Id = 1,
                        Name = Role.Admin,
                        NormalizedName = Role.Admin.ToUpper()
                    }, 
                    new IdentityRole<int>
                    {
                        Id = 2,
                        Name = Role.Entries,
                        NormalizedName = Role.Entries.ToUpper()
                    }, 
                    new IdentityRole<int>
                    {
                        Id = 3,
                        Name = Role.Events,
                        NormalizedName = Role.Events.ToUpper()
                    }, 
                    new IdentityRole<int>
                    {
                        Id = 4,
                        Name = Role.Finance,
                        NormalizedName = Role.Finance.ToUpper()
                    }, 
                    new IdentityRole<int>
                    {
                        Id = 5,
                        Name = Role.News,
                        NormalizedName = Role.News.ToUpper()
                    }, 
                    new IdentityRole<int>
                    {
                        Id = 6,
                        Name = Role.Users,
                        NormalizedName = Role.Users.ToUpper()
                    }
                );

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}