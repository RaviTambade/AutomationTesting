using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staffing.Entity;

namespace Staffing.Repository.Interface
{
    public interface IProductRepo
    {
        public List<Product> GetAll();
        public Product GetById(int id);
        public bool AddProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int id);

    }
}
