
namespace HR.Controllers;

using HR.Entities;


public interface IEmployeeController
{

    public List<Employee> GetAll();
    public Employee Details(int id);
    public bool Post(Employee employee);
    public bool Remove(int id);
    public bool Put(Employee employee);

}
