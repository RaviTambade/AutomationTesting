using System.Collections.Generic;

namespace ECommerce.Catalog
{
    public class ProductManager
    {

        //Member variables
        private List<Product> products = new List<Product>();

        //Member functions
        public List<Product> GetAllProducts()
        {
            return products;
        }
        public Product GetProductById(int productId)
        {
            return products.Find(currentProduct => currentProduct.Id == productId);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(int productId)
        {
            var product = products.Find(currentProduct => currentProduct.Id == productId);
            if (product != null)
            {
                products.Remove(product);
            }
        }

    }
}
