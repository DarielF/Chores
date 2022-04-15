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
        public DbSet<Person> Persons { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
