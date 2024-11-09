namespace Meicrosoft.Customer.Infra.Data;

public class CustomersContext(DbContextOptions<CustomersContext> options) : DbContext(options)
{
    public DbSet<Domain.CustomersAggregate.Customer> Customer { get; set; }
    public DbSet<Address> Address { get; set; }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                ((Entity)entry.Entity).IsDeleted = true;
            }
        }
        return base.SaveChanges();
    }
}
