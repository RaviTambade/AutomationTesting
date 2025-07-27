namespace HR;

public class Employee : Person
{
    public double BasicSalary { get; set; }
    public int DaysWorked { get; set; }

    public double TaxToPay { get; set; }

    public double ComputePay()
    {
        double package = BasicSalary + (DaysWorked * 500) - TaxToPay;
         return package;
    }
    public override string ToString()
    {
       
        return base.ToString() + "  Salary="+ ComputePay() ;
    }
}