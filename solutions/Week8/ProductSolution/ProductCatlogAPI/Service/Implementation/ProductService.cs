using Staffing.Entity;
using Staffing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staffing.Service
{
    public class ProductService : IProductService
    {
        public IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }

        public List<Product> GetProd()
        {
            return _repo.GetAll();
        }

        public Product GetById(int id)
        {
            return _repo.GetById(id);
        }

        public bool AddProduct(Product product)
        {
            bool status = _repo.AddProduct(product);
            return status;
        }

        public bool UpdateProduct(Product product)
        {
            bool status = _repo.UpdateProduct(product);
            return status;
        }

        public bool DeleteProduct(int id)
        {
            bool status = _repo.DeleteProduct(id);
            return status;
        }
    }
}
