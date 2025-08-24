package HR;

public class SalesEmployee extends Employee{
    
    private double salesAmount;
    private double salesCommission;


    public SalesEmployee(String fName,String lName,String contactNo,String email, String locat,double amount,double commission){

        super(fName,lName,contactNo,email,locat);

        this.salesAmount = amount;
        this.salesCommission = commission;
    }

    public double computePay(){
        return this.salesAmount* this.salesCommission;
    }

    @Override
    public String toString() {

        return super.toString() + "SalesAmount =" + this.salesAmount + "SalesCommission =" + this.salesCommission ;
    }

    public static void main (String [] args){

        SalesEmployee salesEmployee = new SalesEmployee("Sandesh", "Jadhav", "1236663773", "s@hsds.com", "UK", 12500, 7000);
        double salary = salesEmployee.computePay();

        System.out.println("Salary :" + salary);
    
    }

}
