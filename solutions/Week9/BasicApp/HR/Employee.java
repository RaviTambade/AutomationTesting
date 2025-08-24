package HR;

public class Employee {
    
    private String firstName;
    private String lastName;
    private String contactNumber;
    private String emailAddress;
    public final String location;

    public Employee(){
        this.firstName ="Vishal";
        this.lastName ="Kolekar";
        this.contactNumber ="8712398838";
        this.emailAddress ="vk@gamil.com";
        this.location ="Pune";
    }

    public Employee(String fName,String lName,String contactNo,String email, String locat){
          this.firstName =fName;
        this.lastName =lName;
        this.contactNumber =contactNo;
        this.emailAddress =email;
        this.location = locat;
    }

    public void setFirstName(String firstname){
         this.firstName = firstname;
    }

    public String getFirstName(){
        return this.firstName;
    }

    public void setLastName(String lastName){
        this.lastName = lastName;
    }

    public String getLastName(){
        return this.lastName;
    }

    public void setContactNo(String contactNo){
        this.contactNumber = contactNo;
    }

    public String getContactNo(){
        return this.contactNumber;
    }

    public void setEmailAddress(String email){
        this.emailAddress = email;
    }

    public String getEmailAddress(){
        return this.emailAddress;
    }

    @Override
    public String toString(){
        return this.firstName + " " + this.lastName + " " + this.contactNumber + " " + 
        this.emailAddress + " " + this.location;
    }
    
    public static void main(String [] args){

        Employee employee1 = new Employee();
        Employee employee2 = new Employee("Aakash","Patil","2322323344","ak@gmail.com","Mumbai");
        // employee2.location="Satara";
        System.out.println(employee1);
        System.out.println(employee2);
    }
}
