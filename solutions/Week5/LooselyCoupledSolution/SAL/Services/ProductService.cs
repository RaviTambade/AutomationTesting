
namespace Catalog;

public class ProductService : IProductService
{

    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }
    public IEnumerable<Product> GetProducts()
    {
        return _repo.GetAll();
    }
}