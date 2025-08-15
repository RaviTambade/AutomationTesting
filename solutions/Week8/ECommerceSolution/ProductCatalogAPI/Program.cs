using ProductCatalogAPI.Entities;
//Minimal Code strategy

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/", () => "Welcome to the Weather Forecast API!");
app.MapGet("/api/products", async () =>
{
   
});

app.MapGet("/api/products/{id}", async (int id) =>
{
    await Task.FromResult(new Product { Id = id, Title = "XBox", Price = 4999.99f, Description = "Smart Gaming Console" });
});

app.MapGet("/api/cart", async () => await Task.FromResult( "List of Items available for Shopping"));
app.MapGet("/api/orders", () => "List of orders placed in last 6 months");
app.MapGet("/api/delivery", () => "Your shipment will be delivered in 24 hours");

app.Run();