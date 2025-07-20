using Catalog;

namespace API;

public class ProductsController : IProductsController
{
    private readonly IProductService _svc;
    public ProductsController(IProductService svc)
    {
        _svc = svc;
    }
    public void Delete(int id)
    {
            //To DO
    }

    public Product Details(int id)
    {
        IEnumerable<Product> products = _svc.GetProducts();
        List<Product> allProducts =(List<Product>) products;
        return allProducts.Find(x => x.Id == id);
    }

    public IEnumerable<Product> Index()
    {
        return _svc.GetProducts();
    }

    public void Post(Product product)
    {
        
    }

    public void Put(int id, Product product)
    {
        
    }
}
