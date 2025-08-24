// import HR.Employee;
// import HR.SalesEmployee;

import HR.*;

public class Test {

    public static void main(String[] args) {

        Employee employee1 = new Employee();
        Employee employee2 = new Employee("Aakash", "Patil", "2322323344", "ak@gmail.com", "Mumbai");
        // employee2.location="Satara";
        System.out.println(employee1);
        System.out.println(employee2);


        SalesEmployee salesEmployee = new SalesEmployee("Sandesh", "Jadhav", "1236663773", "s@hsds.com", "UK", 12500,
                7000);
        double salary = salesEmployee.computePay();

         System.out.println(salesEmployee);
        System.out.println("Salary :" + salary);
    }
}
