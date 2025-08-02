using CRMLib.Entities;
using CRMLib.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // Ensure you have the MySQL.Data package installed
namespace CRMLib.Repositories.Implemenrations
{
    public class CusomerMySQLDBManager : IDBManager
    {
        public bool  Create(Customer item)
        { 
            bool status = false;
            string connectionString = "server=localhost; port=3306;database=CRM;user=root;password=password";
            List<Customer> customers = new List<Customer>();
         
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO Customers  (Name, Address , Phone, Email) Values (@Name, @Address, @Phone, @Email)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", item.Name);
                command.Parameters.AddWithValue("@Address", item.Address);
                command.Parameters.AddWithValue("@Phone", item.Phone);
                command.Parameters.AddWithValue("@Email", item.Email);
                command.ExecuteNonQuery();
                status = true; // Assuming the deletion was successful
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public bool Delete(int  id)
        {
            bool status = false;
            string connectionString = "server=localhost; port=3306;database=CRM;user=root;password=password";
            List<Customer> customers = new List<Customer>();
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM Customers WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                status = true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return status;
        }
      
        public bool Update(Customer item)
        {

            bool status = false;
            // Here you would typically use a MySQL command to delete the customer from the database
            string connectionString = "server=localhost; port=3306;database=CRM;user=root;password=password";
            // Here you would typically use 
            List<Customer> customers = new List<Customer>();
            // Simulating database retrieval

            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "Update  FROM Customers SET ......... WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", item.Id);
                command.ExecuteNonQuery();
                status = true; // Assuming the updation was successful
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public List<Customer> GetAll()
        {
            //returning empty list
            //database connection and retrieval logic would go here

            string connectionString = "server=localhost; port=3306;database=CRM;user=root;password=password";
            // Here you would typically use 
            List<Customer> customers = new List<Customer>();
            // Simulating database retrieval

            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM Customers", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Address = reader.GetString("Address"),
                        Phone = reader.GetString("Phone"),
                        Email = reader.GetString("Email")
                    };
                    customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return customers;
        }

        public Customer Get(int id)
        {
           
            string connectionString = "server=localhost; port=3306;database=CRM;user=root;password=password";
       
            Customer customer = null;
            // Simulating database retrieval
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM Customers WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Address = reader.GetString("Address"),
                        Phone = reader.GetString("Phone"),
                        Email = reader.GetString("Email")
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return customer;
        }
    }
}
