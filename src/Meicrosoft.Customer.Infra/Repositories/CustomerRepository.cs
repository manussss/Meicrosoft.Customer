namespace Meicrosoft.Customer.Infra.Repositories;

public class CustomerRepository(CustomersContext customersContext) : ICustomerRepository
{
    public async Task CreateAsync(Domain.CustomersAggregate.Customer customer)
    {
        await customersContext.AddAsync(customer);
        await customersContext.SaveChangesAsync();
    }

    public async Task<Domain.CustomersAggregate.Customer?> GetByIdAsync(Guid id)
    {
        return await customersContext.Customer.FindAsync(id);
    }

    public async Task DeleteAsync(Guid id)
    {
        customersContext.Remove(id);
        await customersContext.SaveChangesAsync();
    }
}
