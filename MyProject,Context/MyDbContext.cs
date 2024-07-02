using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MyProject.Context
{
    public class MyDbContext : DbContext, IContext
    {
        public DbSet<Customer>? Custumeres { get; set; }
        public DbSet<Driver>? Driveres { get; set; }
        public DbSet<Route>? Routes { get; set; }
        public DbSet<Station>? Stations { get; set; }
        public DbSet<User>? Users { get; set; }
      
        public MyDbContext(DbContextOptions<MyDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(b => b.FirstName)
                .IsRequired();
        }
    }
}
