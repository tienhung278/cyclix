using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class CustomerWriteDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;

    public Customer ToCustomer()
    {
        return new Customer
        {
            FirstName = FirstName,
            LastName = LastName,
            Street = Street,
            HouseNumber = HouseNumber,
            PostCode = PostCode,
            City = City,
            Email = Email,
            Telephone = Telephone
        };
    }
}