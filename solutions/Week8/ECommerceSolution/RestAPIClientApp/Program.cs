
// Inbuilt REST API Client
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;

var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5232/");

try
{
    // GET request
    var response = await client.GetAsync("/api/products");
    response.EnsureSuccessStatusCode();
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("GET Response: " + content);
    // POST request
    var newProduct = new { Id = 101, Title = "Sony Bravio", Price = 2999.99f, Description = "A brand new TV" };


    var postContent = new StringContent(JsonSerializer.Serialize(newProduct), Encoding.UTF8, "application/json");
    var postResponse = await client.PostAsync("/api/products", postContent);
    postResponse.EnsureSuccessStatusCode();
    Console.WriteLine("POST Response: " + await postResponse.Content.ReadAsStringAsync());

    // PUT request
    var updatedProduct = new { Id = 101, Title = "Updated Product", Price = 899.99f, Description = "An updated product" };
    var putContent = new StringContent(JsonSerializer.Serialize(updatedProduct), Encoding.UTF8, "application/json");
    var putResponse = await client.PutAsync("101", putContent);
    putResponse.EnsureSuccessStatusCode();
    Console.WriteLine("PUT Response: " + await putResponse.Content.ReadAsStringAsync());
    
    // DELETE request
    var deleteResponse = await client.DeleteAsync("101");
    deleteResponse.EnsureSuccessStatusCode();
    Console.WriteLine("DELETE Response: " + await deleteResponse.Content.ReadAsStringAsync());


}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
finally
{
    client.Dispose();
}
