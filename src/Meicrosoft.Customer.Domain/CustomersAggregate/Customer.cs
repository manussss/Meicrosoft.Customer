namespace Meicrosoft.Customer.Domain.CustomersAggregate;

public class Customer : Entity
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void SetAddress(Address address)
    {
        Address = address;
    }
}
