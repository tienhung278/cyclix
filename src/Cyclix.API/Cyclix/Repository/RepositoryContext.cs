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
    public DbSet<Request> Requests { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<RequestPackage> RequestPackages { get; set; }
    public DbSet<RequestOption> RequestOptions { get; set; }
    public DbSet<RequestAnotherOption> RequestAnotherOptions { get; set; }

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
        
        modelBuilder.Entity<RequestPackage>().HasData
        (
            new RequestPackage { RequestId = 1, PackageId = 1 }
        );
        
        modelBuilder.Entity<RequestOption>().HasData
        (
            new RequestOption { RequestId = 1, OptionId = 1 }
        );
        
        modelBuilder.Entity<RequestAnotherOption>().HasData
        (
            new RequestAnotherOption { RequestId = 1, AnotherOptionId = 1 }
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
        
        modelBuilder.Entity<RequestPackage>().HasKey(bp => new { bp.RequestId, bp.PackageId });
        modelBuilder.Entity<RequestOption>().HasKey(bo => new { bo.RequestId, bo.OptionId });
        modelBuilder.Entity<RequestAnotherOption>().HasKey(bao => new { bao.RequestId, bao.AnotherOptionId });

        var request = new Request
        {
            Id = 1,
            BrandId = 1,
            CustomerId = 1,
            ServiceId = 1,
            TypeId = 1,
            Description = "Description",
            Note = "Note"
        };
        modelBuilder.Entity<Request>().HasData(request);
    }
}