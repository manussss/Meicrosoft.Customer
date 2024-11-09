namespace Meicrosoft.Customer.Application.Services.Contracts;

public interface ICustomerService
{
    Task CreateAsync(CreateCustomerDto dto);
    Task DeleteAsync(Guid id);
}
