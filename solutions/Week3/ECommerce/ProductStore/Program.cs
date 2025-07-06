using Catalog;

//Integration of Product and ProductManager classes

Product p1 = new Product();
p1.Id = 1;
p1.Title = "Lotus";
p1.Category = "Flowers";
p1.Description = "A worship flower.";
p1.Price = 50.00m;


Product p2 = new Product();

p2.Id = 2;
p2.Title = "Rose";
p2.Category = "Flowers";
p2.Description = "A symbol of love.";
p2.Price = 50.00m;

List<Product> products = new List<Product>();
products.Add(p1);
products.Add(p2);

ProductManager productManager = new ProductManager();
foreach (Product product in products)
{
    productManager.Display(product);
    Console.WriteLine();
}
