using ProductCatalogAPI.Entities;
namespace ProductCatalogAPI.Repositories
{
    public interface IProductRespository
    {
        //CRUD Operations
         Task<IEnumerable<Product>> GetProductsAsync();
         Task<Product> GetProductAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);

    }
}
