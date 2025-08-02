using CRMLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLib.Repositories.Interfaces
{
    //interfaces are supposed to be public
    //interfaces are immutable

    public interface IDBManager
    {
        //CRUD operations
        bool Create(Customer item);
        bool  Update (Customer  item);
        bool Delete(int id);
        List<Customer> GetAll();

        Customer Get(int id);

    }
}


//strong type and weak type

//Whenever you start using  Generics,
//you are using strong type (type safe programming