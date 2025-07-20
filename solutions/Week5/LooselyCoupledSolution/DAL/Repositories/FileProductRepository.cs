

namespace Catalog;


public class FileProductRepository : IProductRepository
{
    public void Add(Product product)
    {

        //add new Product to file
       
    }

    public void Delete(int id)
    {
        //remove product from file
    }

    public IEnumerable<Product> GetAll()
    {

        //get data from file
        List<Product> products = new List<Product>();
        return  products;


    }

    public Product GetById(int id)
    {

        //get data from file
        Product product = GetAll().FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return null;
        }
        return product;
    }

    public void Update(Product product)
    {
        
        //update data to file
    }
}