namespace Meicrosoft.Customer.Application.Dtos;

public class CreateAddressDto
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string Number { get; private set; }
    public string ZipCode { get; private set; }
}
