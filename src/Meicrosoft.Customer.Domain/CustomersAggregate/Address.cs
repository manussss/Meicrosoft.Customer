namespace Meicrosoft.Customer.Domain.CustomersAggregate;

public class Address : Entity
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string Number { get; private set; }
    public string ZipCode { get; private set; }
    public Guid CustomerId { get; private set; }
    public Customer? Customer { get; private set; }

    public Address(string street, string city, string number, string zipCode)
    {
        Street = street;
        City = city;
        Number = number;
        ZipCode = zipCode;
    }

    public void SetCustomer(Guid customerId)
    {
        CustomerId = customerId;
    }
}
