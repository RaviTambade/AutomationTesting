
using Catalog;

namespace API;

public interface IProductsController
{
    IEnumerable<Product> Index();
    Product Details(int id);
    void Post(Product product);
    void Delete(int id);
    void Put(int id, Product product);
}
