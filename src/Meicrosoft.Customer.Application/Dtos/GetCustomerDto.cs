namespace Meicrosoft.Customer.Application.Dtos;

public class GetCustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public GetAddressDto Address { get; set; }
}
