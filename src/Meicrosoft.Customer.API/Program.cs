var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

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

app.Run();
