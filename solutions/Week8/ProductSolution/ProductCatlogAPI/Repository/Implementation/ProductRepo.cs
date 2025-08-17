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

        string connectionString = "server = localhost; port=3306; database = ProductMaster; user= root; password = password ";
        bool status = false;


        public ProductRepo()
        {
            // Constructor can be used for initialization if needed
        }
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM PRODUCT WHERE Id =@Id", connection);

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
            catch (Exception ex)
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
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO PRODUCT (Title,Description,Stock) Values (@Title,@Description,@Stock)",connection);
               
                cmd.Parameters.AddWithValue("@Title", product.Title);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Stock", product.Stock);

                cmd.ExecuteNonQuery();
                status = true;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return status;
        }

        public bool UpdateProduct(Product product)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = "UPDATE PRODUCT SET Title= @Title, Description = @Description, Stock=@Stock WHERE Id=@Id ";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Title", product.Title);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Stock", product.Stock);

                command.ExecuteNonQuery();
                status = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }
        public bool DeleteProduct(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM PRODUCT WHERE Id =@Id", connection);

                cmd.Parameters.AddWithValue("Id", id);
                cmd.ExecuteNonQuery();

                status = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return status;
        }
    }
}