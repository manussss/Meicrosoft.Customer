namespace Meicrosoft.Customer.Application.Services.Contracts;

public interface ICustomerService
{
    Task CreateAsync(CreateCustomerDto dto);
    Task<GetCustomerDto?> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<GetCustomerDto>> GetAllAsNoTrackingAsync();
}
