using System.Text.Json;
using System.IO;
using JsonSeriaizationApp.Entities;


Product product1 = new Product();
product1.Id = 23;
product1.Name = "Gerbera";
product1.Description = "Wedding Flower";
product1.Price = 11;

Product product2 = new Product();
product2.Id = 24;
product2.Name = "Rose";
product2.Description = "Valentine Flower";
product2.Price = 28;

Product product3 = new Product();
product3.Id = 25;
product3.Name = "Lotus";
product3.Description = "Worship Flower";
product3.Price = 40;

List<Product> allFlowers = new List<Product>();
allFlowers.Add(product1);
allFlowers.Add(product2);
allFlowers.Add(product3);


string filePath = @"D:\tryout\products.json";

string jsonString = JsonSerializer.Serialize(allFlowers);
File.WriteAllText(filePath, jsonString);

string retrivedJsonString = File.ReadAllText(filePath);

List<Product> allRestoredProducts = JsonSerializer.Deserialize<List<Product>>(retrivedJsonString);

foreach (Product retrivedProduct in allRestoredProducts)
{
    Console.WriteLine(retrivedProduct.Name + " " + retrivedProduct.Description);
}


