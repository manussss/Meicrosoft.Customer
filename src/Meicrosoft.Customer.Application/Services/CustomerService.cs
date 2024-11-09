namespace Meicrosoft.Customer.Application.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public async Task CreateAsync(CreateCustomerDto dto)
    {
        var customer = new Domain.CustomersAggregate.Customer(dto.Name);
        var address = new Address(dto.Address.Street, dto.Address.City, dto.Address.Number, dto.Address.ZipCode);

        address.SetCustomer(customer.Id);
        customer.SetAddress(address);

        await customerRepository.CreateAsync(customer);
    }

    public async Task<GetCustomerDto?> GetByIdAsync(Guid id)
    {
        var customer = await customerRepository.GetByIdAsync(id);

        if (customer == null)
            return null;

        return new GetCustomerDto
        {
            Name = customer.Name,
            Address =
            {
                City = customer.Address.City,
                Number = customer.Address.Number,
                ZipCode = customer.Address.ZipCode,
                Street = customer.Address.Street
            }
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        await customerRepository.DeleteAsync(id);
    }
}
