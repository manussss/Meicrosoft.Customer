var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var applyMigrations = builder.Configuration.GetValue<bool>("APPLY_MIGRATIONS");

if (applyMigrations)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<CustomersContext>();
        dbContext.Database.Migrate();
    }
}

app.MapPost("api/v1/customers", async (
    [FromServices] ICustomerService customerService,
    CreateCustomerDto dto) =>
{
    await customerService.CreateAsync(dto);

    return Results.Created();
});

app.MapDelete("api/v1/customers/{id}", async (
    [FromServices] ICustomerService customerService,
    Guid id) =>
{
    await customerService.DeleteAsync(id);

    return Results.NoContent();
});

app.MapGet("api/v1/customers/{id}", async (
    [FromServices] ICustomerService customerService,
    Guid id) =>
{
    var customer = await customerService.GetByIdAsync(id);

    if (customer == null)
        return Results.NotFound();

    return Results.Ok(customer);
});

app.MapGet("api/v1/customers", async ([FromServices] ICustomerService customerService) =>
{
    var customers = await customerService.GetAllAsNoTrackingAsync();

    if (customers == null)
        return Results.NotFound();

    return Results.Ok(customers);
});

app.Run();
