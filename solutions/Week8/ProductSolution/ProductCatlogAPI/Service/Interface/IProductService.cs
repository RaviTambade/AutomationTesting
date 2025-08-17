using Staffing.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staffing.Service
{
    public interface IProductService
    {
        public List<Product> GetProd();
        public Product GetById(int id);
        public bool AddProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int id);
        
    }
}
