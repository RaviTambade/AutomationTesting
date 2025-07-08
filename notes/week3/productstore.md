## 🌸 The Tale of Product Store and the Flower Bazaar App

Once upon a time, in the land of **Object-Oriented Programming**, our young developer decided to build a humble yet meaningful console app — a **Product Store**. But not just any store — this one sold **flowers** 🌷🌻🌺.


### 🧱 Chapter 1: Setting Up the Flower Shop 🏪

Our developer first laid the bricks — building a simple `.NET console application`.

🧙‍♂️**Spell used**:

```bash
dotnet new console -n FlowerStoreApp
```

Then he stepped into the magical terminal and whispered:

```csharp
Console.WriteLine("Welcome to the Product Store!");
```

And thus began the journey... 🌼


### 🌹 Chapter 2: Modeling the Flowers – Enter the `Product` Class

> "We need to describe our flowers — every flower has a name, a category, a price, and a description."

He created a blueprint called `Product.cs`:

```csharp
namespace Catalog
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string Category { get; set; }
    }
}
```

This was the **soul** of every flower 🌸 in our bazaar.

### 🧪 Chapter 3: Testing the First Flower

He now created an instance of a `Product`:

```csharp
Product p1 = new Product();
p1.Title = "Lotus";
p1.Description = "Worship flower";
p1.UnitPrice = 23.00M;
p1.Category = "Flowers";
```

Just like labeling a bouquet — he gave it a name, purpose, price, and type.

### 🔁 Chapter 4: Console is the Display Counter

Now he wanted to **display** the flower to the world:

```csharp
Console.WriteLine("Product Title: " + p1.Title);
Console.WriteLine("Category: " + p1.Category);
Console.WriteLine("Description: " + p1.Description);
Console.WriteLine("Unit Price: ₹" + p1.UnitPrice);
```

And the console smiled back, showing the neatly printed label.

### 🧱 Chapter 5: From Monolith to Modular 🧩

At first, all this logic was jammed inside `Program.cs`. Ravi paused...

> "This is monolithic! All logic is mixed — creation, display, management — it’s a mess!"

So, like a wise architect, he separated the concerns.

He created a **ProductManager.cs** file — a helper, a shopkeeper, who would only handle product **display**:

```csharp
public class ProductManager
{
    public void Display(Product product)
    {
        Console.WriteLine("Title: " + product.Title);
        Console.WriteLine("Category: " + product.Category);
        Console.WriteLine("Description: " + product.Description);
        Console.WriteLine("Price: ₹" + product.UnitPrice);
        Console.WriteLine("-----------------------------");
    }
}
```

### 🌈 Chapter 6: Two Flowers, One Store

He went back to `Program.cs` and created more products:

```csharp
Product p2 = new Product
{
    Title = "Valentine Rose",
    Description = "Best for gifting",
    UnitPrice = 45.50M,
    Category = "Flowers"
};
```

And then, just like setting up a shelf, he added both products to a **list**:

```csharp
List<Product> products = new List<Product>();
products.Add(p1);
products.Add(p2);
```
### 🔄 Chapter 7: For Each Flower, Display Its Details 🌼

Then he told the shopkeeper:

```csharp
ProductManager manager = new ProductManager();

foreach (Product p in products)
{
    manager.Display(p);
}
```

Each flower was taken out of the basket and gracefully presented.

### 📋 Chapter 8: Step-by-Step Wisdom

Ravi, the mentor, then gave the students a map — a **7-step formula** for building object-oriented apps:

1. ✅ Create a Console Application
2. ✅ Create a `Product` class with properties: Id, Title, Description, Price, Category
3. ✅ Create a `ProductManager` class with a `Display()` method
4. ✅ Create 2 `Product` objects in `Program.cs`
5. ✅ Create a list of products
6. ✅ Add product objects to the list
7. ✅ Use a `foreach` loop to show all products using `ProductManager`

> "This structure gives you **clarity**, **reusability**, and **scalability**. This is how we move from monolithic chaos to modular elegance."

### 💡 Final Thoughts from the Mentor

> "Object-Oriented Programming is like managing a real store.
> Every item is a product (class),
> every worker has a role (manager class),
> and every action should be neat, clear, and testable."

And with that, the young programmers had not just learned syntax — they had built a **living, breathing digital flower shop**! 💐

