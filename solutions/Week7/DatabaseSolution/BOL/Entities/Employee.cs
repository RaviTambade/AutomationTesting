namespace HR.Entities;


public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Employee other)
            return this.Id == other.Id;
        return false;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

}