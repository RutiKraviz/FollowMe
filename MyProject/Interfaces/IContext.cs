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
        DbSet<Costumer>? Costumeres { get; set; }

        DbSet<Driver>? Driveres { get; set; }

        DbSet<Route>? Routes { get; set; }

        DbSet<Station>? Stations { get; set; }

        DbSet<User>? Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    }
}
