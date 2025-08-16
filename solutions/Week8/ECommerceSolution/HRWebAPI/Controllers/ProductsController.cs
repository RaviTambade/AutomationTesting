using HRWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return   new List<Product>() {
                            new Product { Id = 23, Title = "XBox", Price = 40000f, Description = "Smart Gaming Console Microsoft" },
                            new Product { Id = 65, Title = "PS5", Price = 50000f, Description = "Smart Gaming Console Sony" },
                            new Product { Id = 88, Title = "Nintendo", Price = 6000f, Description = "Smart Gaming Console Nintendo" }

            };
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return new Product { Id = 65, Title = "PS5", Price = 50000f, Description = "Smart Gaming Console Sony" };
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            // Here you would typically add the product to a database or a collection


        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            // Here you would typically update the product in a database or a collection
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Here you would typically delete the product from a database or a collection
        }
    }
}
