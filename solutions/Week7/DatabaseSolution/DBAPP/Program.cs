using MySql.Data.MySqlClient;


//1.Define the connection string
//Create connection object
//2.Create Command Object
//open connecto
//3.Execute the command
//4.Process the results
//show results
//close connection

string connString = "server=localhost; port=3306; database='ecommerce'; user=root; password=password";
MySqlConnection conn = new MySqlConnection(connString);
MySqlCommand cmd = new MySqlCommand("SELECT * FROM entries", conn);
try
{
    conn.Open();
    MySqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"ID: {reader["id"]}, Status: {reader["status"]}");
    }

    reader.Close();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
    conn.Close();
}
