namespace HR.Repository;

using HR.Utility;
using HR.Entities;

public class EmployeeRepository : IEmployeeRepository{

    List<Employee> allEmployees = null;
    string filePath =@"D:\tryout\Employee.json";

    public EmployeeRepository()
    {

        allEmployees = new List<Employee>();
    }

    public Employee GetById(int id){

        List<Employee> allEmployees = GetAll() as List<Employee>;
        Employee theEmployee = allEmployees.Find(x => x.Id == id);
        return theEmployee;
    }

    public List<Employee> GetAll(){
        List<Employee> allEmployees = JsonFileManager.Load(filePath);
        return allEmployees;
    }

    public bool Add(Employee employee)
    {
        List<Employee> allEmployees = GetAll() as List<Employee>;
        allEmployees.Add(employee);
        bool status = JsonFileManager.Save(filePath, allEmployees);
        return status;
    }

    public bool Update(Employee employee)
    {
        Employee foundEmployee = GetById(employee.Id);
        if (foundEmployee != null)
        {
            foundEmployee.Id = employee.Id;
            foundEmployee.Name = employee.Name;
            foundEmployee.Position = employee.Position;
        }
        bool status = JsonFileManager.Save(filePath, allEmployees);
        return status;
    }

    public bool Remove(int id)
    {
        bool status = false;
        List<Employee> allEmployees = GetAll() as List<Employee>;
        Employee foundEmployee = GetById(id);
        if (foundEmployee != null)
        {
            int numDeleted=allEmployees.RemoveAll(e => e.Id == foundEmployee.Id);
            if (numDeleted > 0)
            {
                status = true;
            }
        }

        if (status)
        {
            status = JsonFileManager.Save(filePath, allEmployees);
        }
        return status;
    }
}