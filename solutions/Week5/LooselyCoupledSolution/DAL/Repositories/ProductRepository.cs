
namespace Catalog;
public class ProductRepository : IProductRepository
{
     List<Product> allProducts=null;

    public ProductRepository()
    {
        allProducts=new List<Product>();
    }
    public void Add(Product product)
    {
        allProducts.Add(product);
    }

    public void Delete(int id)
    {
        Product foundProduct = GetById(id);
        if (foundProduct != null)
        {
            allProducts.Remove(foundProduct);
        }
    }

    public IEnumerable<Product> GetAll()
    {
        Product p1 = new Product { Id = 12, Name = "Gerbera", Quantity = 12 };
        allProducts.Add(p1);
        Product p2 = new Product { Id = 13, Name = "Rose", Quantity = 34 };
        allProducts.Add(p2);
        Product p3 = new Product { Id = 124, Name = "Lotus", Quantity = 66};
        allProducts.Add(p3);

        Product p4 = new Product { Id = 124, Name = "Jasmine", Quantity = 78};
        allProducts.Add(p4);
        return allProducts;
    }

    public Product GetById(int id)
    {
        /* Product foundProduct = null;
         foreach (Product p in allProducts) {
             if (p.Id == id) {
                 foundProduct = p;
             }
         }
         return foundProduct;
         */
        Product theProduct = allProducts.Find(x => (x.Id == id));
        return theProduct;
    }

    public void Update(Product product)
    {
        //logic for updation of product;
        Product foundProduct = GetById(product.Id);
        foundProduct = product;
    }
}