using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities.MyProject.Repositories.Entities;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;

public class MyDbContext : DbContext, IContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<User> Users { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map each entity to a separate table
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Driver>().ToTable("Drivers");
        modelBuilder.Entity<Route>().ToTable("Routes");
        modelBuilder.Entity<Station>().ToTable("Stations");

        modelBuilder.Entity<Route>()
            .HasMany(r => r.Stations)
            .WithOne()
            .HasForeignKey(s => s.RouteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Station>()
            .Property(s => s.FullAddress)
            .IsRequired();

        // Ensure the derived types have the same key as the base type
        modelBuilder.Entity<Customer>()
            .HasBaseType<User>();

        modelBuilder.Entity<Driver>()
            .HasBaseType<User>();
    }
}
