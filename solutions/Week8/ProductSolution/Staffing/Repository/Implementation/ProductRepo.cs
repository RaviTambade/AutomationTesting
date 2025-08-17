using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staffing.Entity;
using MySql.Data.MySqlClient;
using Staffing.Repository.Interface;

namespace Staffing.Repository.Implementation
{
    public class ProductRepo : IProductRepo
    {

        List<Product> products = new List<Product>();

        string connectionString = "server = localhost; port=3306; database = product; user= root; password = password ";

        public List<Product> GetAll()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM PRODUCT", connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32("Id"),
                        Title = reader.GetString("Title"),
                        Description = reader.GetString("Description"),
                        Stock = reader.GetInt32("Stock")
                    };

                    products.Add(product);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return products;
        }

        public Product GetById(int id)
        {
            Product product = null;
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
           
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM PRODUCT WHERE Id =@Id",connection);

                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new Product
                    {
                        Id = reader.GetInt32("Id"),
                        Title = reader.GetString("Title"),
                        Description = reader.GetString("Description"),
                        Stock = reader.GetInt32("Stock")
                    };

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
            return product;
        }

        public bool AddProduct(Product product)
        {
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            return true;
        }
        public bool DeleteProduct(int id)
        {
            return true;
        }
    }
}