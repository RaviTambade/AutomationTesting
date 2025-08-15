### 📖 *The Mentor’s Story: Building a Product API the Minimal Way*

*"Imagine you’re opening a brand-new workshop. You don’t start by buying every machine in the catalog. You start with a workbench, a screwdriver, and a hammer. That’s our **minimal code strategy** — only the essentials, no unnecessary ceremony."*

#### **Step 1 — The First Brick: Program.cs**

In the **minimal hosting model** of ASP.NET Core, we no longer have a big Startup.cs file.
Our whole app can start in **Program.cs**.

Here’s the skeleton:

```csharp
using ProductCatalog.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Sample data (our temporary “database”)
List<Product> products = new()
{
    new Product { Id = 1, Title = "Laptop", Description = "Smart laptop", Price = 75000.50m, StockAvailable = 5 },
    new Product { Id = 2, Title = "Phone", Description = "Handy device", Price = 25000.75m, StockAvailable = 10 }
};

// GET all products
app.MapGet("/products", () => products);

// GET product by id
app.MapGet("/products/{id:int}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

// CREATE product
app.MapPost("/products", (Product newProduct) =>
{
    newProduct.Id = products.Max(p => p.Id) + 1;
    products.Add(newProduct);
    return Results.Created($"/products/{newProduct.Id}", newProduct);
});

// UPDATE product
app.MapPut("/products/{id:int}", (int id, Product updatedProduct) =>
{
    var existing = products.FirstOrDefault(p => p.Id == id);
    if (existing is null) return Results.NotFound();

    existing.Title = updatedProduct.Title;
    existing.Description = updatedProduct.Description;
    existing.Price = updatedProduct.Price;
    existing.StockAvailable = updatedProduct.StockAvailable;
    return Results.Ok(existing);
});

// DELETE product
app.MapDelete("/products/{id:int}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product is null) return Results.NotFound();
    products.Remove(product);
    return Results.NoContent();
});

app.Run();
```
#### **Step 2 — The Shape of a Product**

The `Entities/Product.cs` is simple:

```csharp
namespace ProductCatalog.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }
    }
}
```

#### **Step 3 — The Mentor’s Philosophy**

\*"Look, this is our first sprint. No controllers, no repository yet.
We keep the code **close to the metal** — Program.cs directly maps routes to actions.
Later, when the shop grows, we’ll hire specialists:

* **Repositories** for data persistence
* **Services** for business logic
* **Dependency Injection** to decouple code\*

"But right now, the goal is **momentum**. In one sitting, we can test every endpoint in **Swagger** or **Postman** and have working CRUD."

#### **Step 4 — Why This Works**

* **Minimal Code** = less friction, faster learning
* **Strong Typing** = compile-time safety (Product model)
* **REST Style** = predictable endpoints (`/products`, `/products/{id}`)
* **Ready to Grow** = can evolve into layered architecture without rewriting from scratch

 
Alright — let’s do a **Product CRUD API** in ASP.NET Core Web API with a **minimal code strategy** so it’s clean, maintainable, and production-friendly without unnecessary scaffolding.

We’ll use:

* **.NET 8 Minimal APIs** (fewer files, faster to build)
* **Entity Framework Core** (for DB persistence)
* **In-memory DB** for quick demo (can swap to SQL Server easily)

## **1️⃣ Project Setup**

```bash
dotnet new webapi -n ProductApi --use-minimal-apis
cd ProductApi
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```
## **2️⃣ Product Model**

`Models/Product.cs`

```csharp
namespace ProductApi.Models;

public class Product
{
    public int Id { get; set; }         // Primary key
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
```

## **3️⃣ DbContext**

`Data/AppDbContext.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
}
```

## **4️⃣ Program.cs – Minimal API Routes**

`Program.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

var builder = WebApplication.CreateBuilder(args);

// EF Core InMemory DB
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ProductDb"));

var app = builder.Build();

app.MapGet("/", () => "Product API is running...");

// CREATE
app.MapPost("/products", async (AppDbContext db, Product product) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/products/{product.Id}", product);
});

// READ ALL
app.MapGet("/products", async (AppDbContext db) =>
    await db.Products.ToListAsync());

// READ ONE
app.MapGet("/products/{id}", async (AppDbContext db, int id) =>
    await db.Products.FindAsync(id) is Product p ? Results.Ok(p) : Results.NotFound());

// UPDATE
app.MapPut("/products/{id}", async (AppDbContext db, int id, Product inputProduct) =>
{
    var product = await db.Products.FindAsync(id);
    if (product is null) return Results.NotFound();

    product.Name = inputProduct.Name;
    product.Price = inputProduct.Price;
    product.Stock = inputProduct.Stock;
    await db.SaveChangesAsync();

    return Results.Ok(product);
});

// DELETE
app.MapDelete("/products/{id}", async (AppDbContext db, int id) =>
{
    var product = await db.Products.FindAsync(id);
    if (product is null) return Results.NotFound();

    db.Products.Remove(product);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
```

## **5️⃣ Run & Test**

```bash
dotnet run
```

* API runs on: `https://localhost:5001`
* Test using **Postman**, **curl**, or browser:

```bash
curl -X POST https://localhost:5001/products \
     -H "Content-Type: application/json" \
     -d '{"name":"Laptop","price":1200,"stock":10}'
```


## **6️⃣ Why This is “Minimal Code Strategy”**

* **Only 3 files** (Model, DbContext, Program.cs)
* No controllers, no DTO mapping unless needed
* Async EF Core calls for scalability
* Swap InMemory DB with SQL Server by replacing:

```csharp
.UseInMemoryDatabase("ProductDb")
```

with:

```csharp
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
```

