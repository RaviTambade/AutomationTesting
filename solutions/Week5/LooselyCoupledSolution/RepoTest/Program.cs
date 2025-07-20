
using Catalog;
using API;
//SOLID : Design Principle
//S: Single Responsibility Priniciple
//O: Open Closed Principle: Open for extenstion and close for modification
//L: Liskov's Substitution Principle
//I :Interface Saggrigration Principle
//D :Dependency Injection


//DI:
//1 . Constructor DI
//2 . Method DI
//3 . Property DI 



IProductRepository repository = new ProductRepository();
IProductService productService = new ProductService(repository);
IProductsController controller = new ProductsController(productService);

IEnumerable<Product> products = controller.Index();
foreach (Product product in products)
{

    Console.WriteLine(product.Id);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Quantity);
}

//MVP
//MVC
//MVVM
//MV*