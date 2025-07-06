
using System.ComponentModel.DataAnnotations;
namespace Drawing;

public class Line
{
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public Line(Point startPoint, Point endPoint)
    {
        this.StartPoint = startPoint;
        this.EndPoint = endPoint;
    }

    public void Display()
    {
        Console.WriteLine("Line Details");
        this.StartPoint.Display();
        this.EndPoint.Display();
    }
}