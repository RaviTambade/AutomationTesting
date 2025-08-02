namespace HR.Services;
using HR.Entities;
using System.Collections.Generic;

public interface IEmployeeService{

   public List<Employee> GetAll();
   public Employee GetById(int id);

   public bool Add(Employee employee);
   public bool Update(Employee employee);
   public bool Remove(int id);
}