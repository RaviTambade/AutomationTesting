namespace UI;

public class UIManager
{
    public void ShowMenu()
    {
        Console.WriteLine("Welcome to Graphics Solution");
        Console.WriteLine("Choose Option from Menue");
        Console.WriteLine("1. Create Line ");
        Console.WriteLine("2. Create circle ");
        Console.WriteLine("3. Exit ");

    }

    public int GetChoice()
    {
        Console.WriteLine("Enter your choice ");
        int choice = int.Parse(Console.ReadLine());
        return choice;
    }

    public Point GetPoint()
    {

    }
    
    
}