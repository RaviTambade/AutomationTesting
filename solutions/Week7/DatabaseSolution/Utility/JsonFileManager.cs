namespace HR.Utility;

using HR.Entities;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

public class JsonFileManager
{

    public static List<Employee> Load(string filePath)
    {
        string retriveJsonString = File.ReadAllText(filePath);

        List<Employee> allRestoredEmployees = JsonSerializer.Deserialize<List<Employee>>(retriveJsonString);

        return allRestoredEmployees;

    }

    public static bool Save(string filePath, List<Employee> allEmployees) {
        bool status = false;
        string jsonString = JsonSerializer.Serialize(allEmployees);
        File.WriteAllText(filePath, jsonString);

        status = true;

        return status;
    }

}
