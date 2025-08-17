using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;


var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5299/");

try
{
    var response = await client.GetAsync("api/product");
    response.EnsureSuccessStatusCode();
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Get Response : " + content);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    client.Dispose();
}