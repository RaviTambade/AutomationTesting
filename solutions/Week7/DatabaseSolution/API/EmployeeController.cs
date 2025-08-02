
namespace HR.Controllers;
using  HR.Entities;

using HR.Services;

public class EmployeeController :IEmployeeController{

    public readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service ){
        _service = service;
    }

    public List<Employee> GetAll(){
         return _service.GetAll();
    }

    public Employee Details(int id){
      return _service.GetById(id);
    }

    public bool Remove(int id){
       return _service.Remove(id);
    }

    public bool Post(Employee employee){
      return _service.Add(employee);
    }

    public bool Put(Employee employee){
       return _service.Update(employee);
    }
}