using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { 
        
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.UserProfile)
                .WithOne(b => b.User)
                .HasForeignKey<UserProfile>(b => b.UserId).OnDelete(DeleteBehavior.Cascade); 

        }

    }
}
