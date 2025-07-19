namespace HR;

public class Employee:IWorker
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Date JoinDate { get; set; }

    public Employee(string firstName, string lastName, Date joinDate)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.JoinDate = joinDate;
    }

    public void Display()
    {
        Console.WriteLine(this.FirstName + " " + this.LastName);
        this.JoinDate.Display();
    }

    public void DoWork()
    {
        
    }

    public void FillTimesheet()
    {
        
    }

    public void AttendMeeting()
    {
        
    }

    public void ApplyForLeave()
    {
        
    }
}