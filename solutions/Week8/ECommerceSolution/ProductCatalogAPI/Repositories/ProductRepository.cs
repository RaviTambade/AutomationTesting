using ProductCatalogAPI.Entities;
namespace ProductCatalogAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllAsync()
        {
            // Implementation placeholder
            return Task.FromResult<IEnumerable<Product>>(new List<Product>());
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            // Implementation placeholder
            return Task.FromResult<Product?>(null);
        }

        public Task AddAsync(Product product)
        {
            // Implementation placeholder
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product)
        {
            // Implementation placeholder
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            // Implementation placeholder
            return Task.CompletedTask;
        }
    }

    
}
