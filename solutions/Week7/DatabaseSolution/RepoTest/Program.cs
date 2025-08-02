using HR.Entities;
using HR.Repository;
using HR.Services;
using HR.Controllers;
using HR.UI;


     IEmployeeRepository _repo = new EmployeeRepository();
     IEmployeeService _service = new EmployeeService(_repo);
     IEmployeeController _ctrl = new EmployeeController(_service);

     UIManager mgr = new UIManager();

while(true){
    mgr.ShowMenu();

    int choice = mgr.GetChoice();

    switch(choice){

         case 1:
               {
                 List<Employee> employees = _ctrl.GetAll() ;
                 mgr.ShowAll(employees);
                 }
              
              break;   

         case 2:
               {
          int id = mgr.AcceptEmployeeId();
               Employee employee = _ctrl.Details(id);
               mgr.Show(employee);
         }
               
              break;

         case 3:
               {
          Employee employee = mgr.AcceptEmployee();

              bool status = _ctrl.Post(employee);
               mgr.ShowMessage("Add", status);
         }
               

              break;

         case 4:
               {
                    int id = mgr.AcceptEmployeeId();
                    Employee employee = _ctrl.Details(id);
                    Employee employeeToUpdate = mgr.AcceptEmployee();
                    bool status = false;
                    if (employee.Id == employeeToUpdate.Id)
                    {
                         status = _ctrl.Put(employeeToUpdate);
                         mgr.ShowMessage("Update", status);

                    }
                    else
                    {
                         mgr.ShowMessage("Update Failure", status);
                    }
             
         }
             
              break;

         case 5 :
               {
          int id = mgr.AcceptEmployeeId();
               bool status = _ctrl.Remove(id);
                mgr.ShowMessage("Delete", status);
         }
              
         break;

         case 6 :
               return 0;
               break;

         default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}