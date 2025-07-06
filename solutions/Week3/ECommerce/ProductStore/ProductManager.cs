namespace Catalog
{
    public class ProductManager
    { 
        public void Display (Product product)
        {
            Console.WriteLine("Title:" + product.Title);
            Console.WriteLine("Category:" + product.Category);
            Console.WriteLine("Description:" + product.Description);
            Console.WriteLine("Price:" + product.Price.ToString("C"));
        }

    }
    
}
    
