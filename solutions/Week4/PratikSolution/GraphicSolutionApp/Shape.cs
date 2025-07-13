namespace Drawing;

public class Shape
{
    protected int Thickness { get; set; }
    protected Color ShapeColor { get; set; }

    //default constructor
    public Shape()
    {
        Thickness = 0;
        ShapeColor = new Color(0, 2, 4);
    }
    //param constructor
    public Shape(int thickness, Color shapecolor)
    {
        this.Thickness = thickness;
        this.ShapeColor = shapecolor;
    }

    public void Display()
    {
        Console.WriteLine("Thickness" + Thickness);
        Console.WriteLine(ShapeColor.Red + " " + ShapeColor.Green + " " + ShapeColor.Blue);
    }

    public virtual void Draw()
    {
        Console.WriteLine("ShapeDrawFunction");
        Console.WriteLine(ShapeColor.Red + " " + ShapeColor.Green + " " + ShapeColor.Blue);
        Console.WriteLine("Thickness" + Thickness);
    }

    

}