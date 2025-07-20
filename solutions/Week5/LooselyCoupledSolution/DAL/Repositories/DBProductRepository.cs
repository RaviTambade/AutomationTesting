
namespace Catalog;

//Application with multiple layers (N Tier Architecture)

//1.UI Layer  (UI Logic)  (HTML, JS, CSS, Angular, react, vue,etc)
//2.Web Layer (Web Logic)  (state mgmt, auth, authoriziation, caching,....)
//3.Service Layer()---
//4.Business Logic Layer (Domain specific logic)
//5.Data Access Logic Layer( DAL)
//6.Data Layer  (file, database, streaming)


public class DBProductRepository : IProductRepository
{
    List<Product> allProducts = null;

    public DBProductRepository()
    {
        allProducts = new List<Product>();
    }
    public void Add(Product product)
    {
        //database code to add new product to table
        allProducts.Add(product);
    }

    public void Delete(int id)
    {
        Product foundProduct = GetById(id);
        if (foundProduct != null)
        {
            // delete product from table
        }
    }

    public IEnumerable<Product> GetAll()
    {
        List<Product> allProductList = new List<Product>();

        //get all products from table and add to allProducts
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
        Product theProduct = null;
        //get product from tables using SELECT Query
        return theProduct;
    }

    public void Update(Product product)
    {
        //logic for updation of product;
        Product foundProduct = GetById(product.Id);
        //Update existing product from table with new product
        foundProduct = product;
    }
}