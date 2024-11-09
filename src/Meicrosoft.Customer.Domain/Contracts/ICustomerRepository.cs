namespace Meicrosoft.Customer.Domain.Contracts;

public interface ICustomerRepository
{
    Task CreateAsync(CustomersAggregate.Customer customer);
    Task<CustomersAggregate.Customer?> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
}
