## ** Product CRUD API (Minimal Code Strategy)**

**Mentor:**
"Alright team, before we jump into today’s REST API coding session, let’s quickly rewind to what we covered last time. Remember the *hospital example*? Where we treated each role — doctor, nurse, receptionist — as an **object** with specific responsibilities?

That’s object orientation in action:

* Identify objects.
* Give them properties (state).
* Give them functions (behavior).
* Delegate the right task to the right object.

When you think about building *real business applications* — e-commerce, tax calculators, library systems — this is exactly how you structure your code.


### **From OOP to Online Applications**

Back in the day, most software was **desktop-based** — single user, running locally, storing data locally. But business has moved online. Today, over **90% of applications are cloud-based**, multi-user, multi-server, distributed.

In this world:

* Your **frontend** might be Angular, React, or Vue.
* Your **backend** might be ASP.NET Core, Node.js, or Django.
* Your **data** is often in SQL Server, MySQL, or NoSQL databases.

And here’s the thing — backend APIs have become the **heartbeat** of this architecture.

### **The Role of APIs**

APIs are like a restaurant waiter.

* The frontend is the customer.
* The backend is the kitchen.
* The API is the waiter, taking orders (requests) and bringing food (responses).

In REST APIs, this waiter uses specific *verbs*:

* **GET** – Bring me a list or a specific item.
* **POST** – Add something new.
* **PUT** – Update something existing.
* **DELETE** – Remove it from the system.

### **Why Minimal API?**

Now, ASP.NET Core has two main ways to build APIs:

1. **Controller-based Web API** — more structure, more files, better for big projects.
2. **Minimal API** — fewer files, fewer lines, faster to get started, perfect for learning.

For today’s agenda, I want you to focus on the **Minimal API** approach — because it lets you see the heart of the logic without too much ceremony.

### **Our Case Study: Product Catalog**

Think about a small online shop:

* **List** all products.
* **Get** details of one product.
* **Add** a new product.
* **Update** a product.
* **Delete** a product.

That’s our CRUD. And here’s the code…

```csharp
// Program.cs
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with in-memory database
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ProductDb"));

// Optional: Swagger for easy testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CRUD Endpoints
app.MapGet("/products", async (AppDbContext db) =>
    await db.Products.ToListAsync());

app.MapGet("/products/{id}", async (int id, AppDbContext db) =>
    await db.Products.FindAsync(id) is Product p ? Results.Ok(p) : Results.NotFound());

app.MapPost("/products", async (Product product, AppDbContext db) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/products/{product.Id}", product);
});

app.MapPut("/products/{id}", async (int id, Product input, AppDbContext db) =>
{
    var product = await db.Products.FindAsync(id);
    if (product is null) return Results.NotFound();
    product.Name = input.Name;
    product.Price = input.Price;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/products/{id}", async (int id, AppDbContext db) =>
{
    var product = await db.Products.FindAsync(id);
    if (product is null) return Results.NotFound();
    db.Products.Remove(product);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

// Data Layer
class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
}

record Product(int Id, string Name, decimal Price);
```

### **Key Takeaways**

* **Minimal API** means less boilerplate → faster learning.
* **EF Core InMemory DB** keeps it simple — no external DB setup.
* **Swagger** gives you a test UI instantly.
* Once you’re comfortable here, moving to a **Controller-based API** is just adding more structure.

**Mentor (smiling):**
"Now that’s all the theory and coding you need to get your *Product Catalog API* up and running. Tomorrow, we’ll talk about *layering this into Services, Repositories, and Controllers* for a more production-ready architecture. But for today — let’s fire up Swagger and add our first product."

