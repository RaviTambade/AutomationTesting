using Staffing.Repository.Implementation;
using Staffing.Repository.Interface;
using Staffing.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Prepare applicaiton for dependency injection
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();
