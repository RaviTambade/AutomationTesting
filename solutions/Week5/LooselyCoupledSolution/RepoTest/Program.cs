
using Catalog;

IProductRepository repository = new ProductRepository();
IEnumerable<Product> products = repository.GetAll();
foreach (Product product in products)
{

    Console.WriteLine(product.Id);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Quantity);
}

