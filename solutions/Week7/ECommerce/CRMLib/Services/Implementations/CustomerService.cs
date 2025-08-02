using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMLib.Entities;
using CRMLib.Repositories;
using CRMLib.Repositories.Implemenrations;
using CRMLib.Services.Interfaces;

namespace CRMLib.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        public void AddCustomer(Customer customer)
        {
            List<Customer> customers = GetCustomers();
            customers.Add(customer);
            new CusomerMySQLDBManager().Create(customer);

        }

        public void DeleteCustomer(int id)
        {
            List<Customer> customers = GetCustomers();
            new CusomerMySQLDBManager().Delete(id);
        }

        public List<Customer> GetCustomers()
        {
            return new CusomerMySQLDBManager().GetAll();
        }

        public void UpdateCustomer(Customer customer)
        {

            new CusomerMySQLDBManager().Update(customer);
        }
    }
}
