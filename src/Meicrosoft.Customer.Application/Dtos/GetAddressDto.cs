namespace Meicrosoft.Customer.Application.Dtos;

public class GetAddressDto
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string ZipCode { get; set; }
    public bool IsDeleted { get; set; }
}
