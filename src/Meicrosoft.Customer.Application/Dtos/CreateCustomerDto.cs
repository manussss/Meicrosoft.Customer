namespace Meicrosoft.Customer.Application.Dtos;

public class CreateCustomerDto
{
    public string Name { get; set; }
    public CreateAddressDto Address { get; set; }
}
