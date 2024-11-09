namespace Meicrosoft.Customer.Domain.CustomersAggregate;

public class Address : Entity
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string Number { get; private set; }
    public string ZipCode { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }
}
