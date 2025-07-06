namespace Drawing;

public class Circle
{
    public int Radius { get; set; }
    public Point Center { get; set; }  //has a relation

    public Circle()
    {
        this.Radius = 0;
        this.Center = new Point(34, 34);
    }

    public Circle(int radius, Point center)
    {
        this.Radius = radius;
        this.Center = center;
    }

    public void Display()
    {
        Console.WriteLine("\n Circle details:");
        Console.WriteLine("Radius=" + this.Radius);
        Console.WriteLine("Center= ");
        this.Center.Display();
    }
}