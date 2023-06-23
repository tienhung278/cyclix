using Cyclix.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cyclix.Repository;

public class RepositoryContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public DbSet<Bike> Bikes { get; set; }
    
    public DbSet<Customer> Customers { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) 
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData
        (
            new Item { Category = "type", Id = 1, Name = "type 1" },
            new Item { Category = "type", Id = 2, Name = "type 2" },
            new Item { Category = "type", Id = 3, Name = "type 3" },
            new Item { Category = "brand", Id = 4, Name = "brand 1" },
            new Item { Category = "brand", Id = 5, Name = "brand 2" },
            new Item { Category = "brand", Id = 6, Name = "brand 3" },
            new Item { Category = "service", Id = 7, Name = "service 1" },
            new Item { Category = "service", Id = 8, Name = "service 2" },
            new Item { Category = "service", Id = 9, Name = "service 3" },
            new Item { Category = "option", Id = 10, Name = "option 1" },
            new Item { Category = "option", Id = 11, Name = "option 2" },
            new Item { Category = "option", Id = 12, Name = "option 3" },
            new Item { Category = "option", Id = 13, Name = "option 4" },
            new Item { Category = "option", Id = 14, Name = "option 5" },
            new Item { Category = "option", Id = 15, Name = "option 6" },
            new Item { Category = "package", Id = 16, Name = "package 1" },
            new Item { Category = "package", Id = 17, Name = "package 2" },
            new Item { Category = "another_option", Id = 18, Name = "another option 1" },
            new Item { Category = "another_option", Id = 19, Name = "another option 2" }
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
    }
}