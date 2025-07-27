using HR;

Employee employee = new Employee();
employee.Name = "Ravi";
employee.BirthDate = new DateTime(1975, 8, 18);
employee.BasicSalary = 75000;
employee.DaysWorked = 25;
employee.TaxToPay = 24000;
Console.WriteLine(employee);
