
namespace HR;

public class Date
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public Date(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public void Display()
    {
        Console.WriteLine("{0}/{1}/{2}", Day, Month, Year);
    }
}