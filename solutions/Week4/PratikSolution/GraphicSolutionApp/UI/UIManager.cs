namespace UI;
using Drawing;

public class UIManager
{
    public void ShowMenu()
    {
        Console.WriteLine("Welcome to Graphic Solutions");
        Console.WriteLine("Choose option from Menu");
        Console.WriteLine("1.Create Line");
        Console.WriteLine("2.Create Circle");
        Console.WriteLine("3.Exit");
    }

    public int GetChoice()
    {
        Console.WriteLine("Enter your choice:");
        int choice = int.Parse(Console.ReadLine());
        return choice;
    }
    public Color AcceptColor()
    {
        Color theColor = new Color(0, 0, 0);
        Console.WriteLine("Color Input");
        Console.WriteLine("Enter Red Value (0, 255)");
        theColor.Red = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Green Value (0, 255)");
        theColor.Green = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Blue Value (0, 255)");
        theColor.Blue = int.Parse(Console.ReadLine());
        return theColor;
    }

    public int AcceptThickness()
    {
        Console.WriteLine("Enter Thinkness");
        int thickness = int.Parse(Console.ReadLine());
        return thickness;
    }

      public int AcceptRadius()
    {
        Console.WriteLine("Enter Radius");
        int radius = int.Parse(Console.ReadLine());
        return radius;
    }

    //DRY
    public Point AcceptPoint()
    {
        Point thePoint = new Point();
        Console.WriteLine("Accept Point Coordinates");
        Console.WriteLine("Enter X value:");
        thePoint.X = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Y value:");
        thePoint.Y = int.Parse(Console.ReadLine());
        return thePoint;
    }
    public Line GetLine()
    {
        Line theLine = new Line();
        theLine.StartPoint = AcceptPoint();
        theLine.EndPoint = AcceptPoint();
        int thickness = AcceptThickness();
        theLine.SetThickness(thickness);
        Color theColor = AcceptColor();
        theLine.SetColor(theColor);
        return theLine;
    }
    
      public Circle GetCircle()
    {
        Circle circle= new Circle();
        circle.Center = AcceptPoint();

        int radius = AcceptRadius();
        circle.Radius=radius;

        int thickness = AcceptThickness();
        circle.SetThickness(thickness);
        Color theColor=AcceptColor();   
        circle.SetColor(theColor);
        return circle;
    }
}