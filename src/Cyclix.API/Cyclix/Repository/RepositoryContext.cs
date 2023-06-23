using Cyclix.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cyclix.Repository;

public class RepositoryContext : DbContext
{
    public DbSet<Entities.Type> Types { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<AnotherOption> AnotherOptions { get; set; }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BikePackage> BikePackages { get; set; }
    public DbSet<BikeOption> BikeOptions { get; set; }
    public DbSet<BikeAnotherOption> BikeAnotherOptions { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) 
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Type>().HasData
        (
            new Entities.Type { Id = 1, Name = "type 1" },
            new Entities.Type { Id = 2, Name = "type 2" },
            new Entities.Type { Id = 3, Name = "type 3" }
        );
        
        modelBuilder.Entity<Brand>().HasData
        (
            new Brand { Id = 1, Name = "brand 1" },
            new Brand { Id = 2, Name = "brand 2" },
            new Brand { Id = 3, Name = "brand 3" }
        );
        
        modelBuilder.Entity<Service>().HasData
        (
            new Service { Id = 1, Name = "service 1" },
            new Service { Id = 2, Name = "service 2" },
            new Service { Id = 3, Name = "service 3" }
        );
        
        modelBuilder.Entity<Package>().HasData
        (
            new Package { Id = 1, Name = "package 1" },
            new Package { Id = 2, Name = "package 2" }
        );
        
        modelBuilder.Entity<Option>().HasData
        (
            new Option { Id = 1, Name = "option 1" },
            new Option { Id = 2, Name = "option 2" },
            new Option { Id = 3, Name = "option 3" },
            new Option { Id = 4, Name = "option 4" },
            new Option { Id = 5, Name = "option 5" },
            new Option { Id = 6, Name = "option 6" }
        );
        
        modelBuilder.Entity<AnotherOption>().HasData
        (
            new AnotherOption { Id = 1, Name = "another option 1" },
            new AnotherOption { Id = 2, Name = "another option 2" }
        );
        
        modelBuilder.Entity<BikePackage>().HasData
        (
            new BikePackage { BikeId = 1, PackageId = 1 }
        );
        
        modelBuilder.Entity<BikeOption>().HasData
        (
            new BikeOption { BikeId = 1, OptionId = 1 }
        );
        
        modelBuilder.Entity<BikeAnotherOption>().HasData
        (
            new BikeAnotherOption { BikeId = 1, AnotherOptionId = 1 }
        );
        
        var customer = new Customer
        {
            Id = 1,
            Email = "abc@test.com",
            Street = "Pham Hung",
            Telephone = "1234567890",
            FirstName = "Hung",
            HouseNumber = "10",
            LastName = "Pham",
            PostCode = "700000",
            City = "Ho Chi Minh"
        };
        modelBuilder.Entity<Customer>().HasData(customer);
        
        modelBuilder.Entity<BikePackage>().HasKey(bp => new { bp.BikeId, bp.PackageId });
        modelBuilder.Entity<BikeOption>().HasKey(bo => new { bo.BikeId, bo.OptionId });
        modelBuilder.Entity<BikeAnotherOption>().HasKey(bao => new { bao.BikeId, bao.AnotherOptionId });

        var bike = new Bike
        {
            Id = 1,
            BrandId = 1,
            CustomerId = 1,
            ServiceId = 1,
            TypeId = 1,
            Description = "Description",
            Note = "Note"
        };
        modelBuilder.Entity<Bike>().HasData(bike);
    }
}