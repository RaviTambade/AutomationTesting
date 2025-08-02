namespace HR.Repository;
using HR.Entities;

public interface IEmployeeRepository{

    Employee GetById(int id);
    List<Employee> GetAll();
    bool Add(Employee Employee);
    bool Update(Employee Employee);
    bool Remove(int id);
}
