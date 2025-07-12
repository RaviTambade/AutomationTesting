
using System.ComponentModel.DataAnnotations;
namespace Drawing;

public class Line : Shape
{
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    // member initialized List
    //Method overloading   (static polymorphism)
    public Line()
    {

    }
    
    
    //Member Initialized List
    public Line(Point startPoint, Point endPoint, int thickness, Color color) : base(thickness, color)
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


    //Method Overriding (dynamic Polymorphism)
    public override void Draw()
    {
        StartPoint.Display();
        EndPoint.Display();
        base.Draw();
    }

}