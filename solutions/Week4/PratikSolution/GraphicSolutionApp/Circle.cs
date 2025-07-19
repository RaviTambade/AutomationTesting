namespace Drawing;

public class Circle:Shape
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

    public Color GetColor()
    {
        return ShapeColor;

    }

    public void SetColor(Color color)
    {
        ShapeColor = color;
    }
    
    public void SetThickness(int thkness)
    {
        Thickness = thkness;
    }


    public void Display()
    {
        Console.WriteLine("\n Circle details:");
        base.Display();
        Console.WriteLine("Radius=" + this.Radius);
        Console.WriteLine("Center= ");
        this.Center.Display();
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing Circle");
        this.Center.Display();
        Console.WriteLine("Radius =" + this.Radius);
        base.Draw();
    }
}