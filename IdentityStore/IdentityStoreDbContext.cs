﻿using ClubIS.IdentityStore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubIS.IdentityStore
{
    public class IdentityStoreUser : IdentityUser<int> { }
    public class IdentityStoreRole : IdentityRole<int> { }
    public class IdentityStoreDbContext : IdentityDbContext<IdentityStoreUser, IdentityStoreRole, int>
    {
        public IdentityStoreDbContext(DbContextOptions<IdentityStoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            var hasher = new PasswordHasher<IdentityStoreUser>();
            builder.Entity<IdentityStoreUser>().HasData(
                new IdentityStoreUser
                {
                    Id = 1,
                    UserName = "matej",
                    NormalizedUserName = "matej",
                    PasswordHash = hasher.HashPassword(null, "matej"),
                    SecurityStamp = string.Empty
                },
                new IdentityStoreUser
                {
                    Id = 2,
                    UserName = "katka",
                    NormalizedUserName = "katka",
                    PasswordHash = hasher.HashPassword(null, "katka"),
                    SecurityStamp = string.Empty
                }
            );
            builder.Entity<IdentityStoreRole>().HasData(
                new IdentityStoreRole { 
                    Id = 1,
                    Name = "admin", 
                    NormalizedName = "admin".ToUpper() 
                }
            );

            // make matej admin
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });
        }

    }
}