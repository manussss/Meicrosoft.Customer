namespace Meicrosoft.Customer.IoC;

public static class ServicesInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>();
    }
}
