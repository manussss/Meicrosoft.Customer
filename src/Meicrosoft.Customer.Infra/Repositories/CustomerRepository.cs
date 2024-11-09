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
        return await customersContext.Customer.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = customersContext.Customer.Find(id);

        if (customer != null)
        {
            customersContext.Remove(customer);
            await customersContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Domain.CustomersAggregate.Customer>> GetAllAsNoTrackingAsync()
    {
        return await customersContext.Customer.Include(c => c.Address).AsNoTracking().ToListAsync();
    }
}
