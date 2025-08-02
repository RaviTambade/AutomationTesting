namespace HR.UI;
using HR.Controllers;
using  HR.Entities;


public class UIManager
{


    public void ShowMenu()
    {
        Console.WriteLine("Welcome To Product Catalog");
        Console.WriteLine("Choose Option from menu");
        Console.WriteLine("1. Get Product List");
        Console.WriteLine("2. Get Product by Id");
        Console.WriteLine("3. Add Product");
        Console.WriteLine("4. Update Product");
        Console.WriteLine("5. Delete Product");
        Console.WriteLine("6. Exit");
    }

    public int GetChoice()
    {
        Console.WriteLine("Enter your choice");
        int choice = int.Parse(Console.ReadLine());
        return choice;
    }

    public void ShowAll(List<Employee> allEmployees)
    {

        Console.WriteLine("Employee List :");
        foreach (Employee employee in allEmployees)
        {
            Console.WriteLine("Employee Id :" + employee.Id + " " + "Employee Name : " + employee.Name + " " + "Position :" + employee.Position);
        }
    }

    public int AcceptEmployeeId()
    {
        Console.WriteLine("Enter Id");
        int foundId = int.Parse(Console.ReadLine());
        return foundId;
    }
    public void Show(Employee employee)
    {

        Console.WriteLine("Employee Id :" + employee.Id + " " + "Employee Name : " + employee.Name + " " + "Position :" + employee.Position);
    }

    public Employee AcceptEmployee()
    {
        Employee employee = new Employee();
        Console.WriteLine("Enter Employee Details");
        Console.WriteLine("Enter Employee Id:");
        int id = int.Parse(Console.ReadLine());
        employee.Id = id;

        Console.WriteLine("Enter Employee Name:");
        string name = Console.ReadLine();
        employee.Name = name;

        Console.WriteLine("Enter Employee Position :");
        string position = Console.ReadLine();
        employee.Position = position;

        return employee;
    }

    public int AcceptEmployeeToUpdate()
    {

        Console.WriteLine("Enter Employee ID to update:");

        int employeeIdToUpdate = AcceptEmployeeId();
        return employeeIdToUpdate;

    }

    public int AcceptEmployeeToDelete()
    {

        Console.WriteLine("Enter Employee ID to delete:");

        int employeeIdToDelete = AcceptEmployeeId();
        return employeeIdToDelete;
    }

    public void ShowMessage(string operation, bool status)
    {
        if (status)
        {
            Console.WriteLine(operation + " Success");
        }
        else
        {
            Console.WriteLine(operation + " Failure");
        }
    }   





}
