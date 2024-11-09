namespace Meicrosoft.Customer.IoC
{
    public static class DatabaseInjection
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomersContext>(options => options.UseSqlServer(configuration.GetConnectionString("CustomersConnection")));
        }
    }
}
