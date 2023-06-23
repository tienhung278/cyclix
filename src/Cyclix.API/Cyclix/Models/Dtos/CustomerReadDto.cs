using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class CustomerReadDto
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;

    public CustomerReadDto(Customer customer)
    {
        Id = customer.Id;
        FirstName = customer.FirstName;
        LastName = customer.LastName;
        HouseNumber = customer.HouseNumber;
        Street = customer.Street;
        PostCode = customer.PostCode;
        City = customer.City;
        Email = customer.Email;
        Telephone = customer.Telephone;
    }
}