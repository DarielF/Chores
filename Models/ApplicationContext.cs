using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TaskManager
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Chore> Chores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserChores> UserChores { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserChores>().HasKey(x => new { x.ChoreId, x.UserId });
            modelBuilder.Entity<UserChores>().HasOne(x=> x.Chore)
                .WithMany(x=> x.UserChores)
                .HasForeignKey(x=> x.ChoreId);

            modelBuilder.Entity<UserChores>().HasOne(x => x.User)
               .WithMany(x => x.UserChores)
               .HasForeignKey(x => x.UserId);

        }

    }
}
