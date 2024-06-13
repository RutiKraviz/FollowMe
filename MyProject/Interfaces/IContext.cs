using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IContext
    {
        public DbSet<Coustemer> Costumeres { get; set; }

        public DbSet<Driver> Driveres { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
