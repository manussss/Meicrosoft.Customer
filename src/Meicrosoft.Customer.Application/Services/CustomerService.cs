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
            IsDeleted = customer.IsDeleted,
            Address = new GetAddressDto
            {
                City = customer.Address.City,
                Number = customer.Address.Number,
                ZipCode = customer.Address.ZipCode,
                Street = customer.Address.Street,
                IsDeleted = customer.Address.IsDeleted
            }
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        await customerRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<GetCustomerDto>> GetAllAsNoTrackingAsync()
    {
        var customers = await customerRepository.GetAllAsNoTrackingAsync();

        if (customers is null)
            return null;

        return customers.Select(customer => new GetCustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            IsDeleted = customer.IsDeleted,
            Address = new GetAddressDto
            {
                Id = customer.Address.Id,
                ZipCode = customer.Address.ZipCode,
                Street = customer.Address.Street,
                City = customer.Address.City,
                Number = customer.Address.Number,
                IsDeleted = customer.Address.IsDeleted
            }
        });
    }
}
