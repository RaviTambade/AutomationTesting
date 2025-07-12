namespace Drawing;

using System.Collections.Generic;

public class Shape
{
    protected int Thickness { get; set; }
    protected Color ShapeColor { get; set; }

    public Shape()
    {
        Thickness = 0;
        ShapeColor = new Color(0,0,0);
      
    }
    public Shape(int thickness, Color shapeColor)
    {
        Thickness = thickness;
        ShapeColor = shapeColor;
    }

    public void Display()
    {
        Console.WriteLine("Thickness= " + Thickness);
        Console.WriteLine(ShapeColor.Red + " " + ShapeColor.Green + " " + ShapeColor.Blue);
    }


    public  virtual void Draw()
    {
        Console.WriteLine("Shape Drawing");
        Console.WriteLine(ShapeColor.Red + " " + ShapeColor.Green + " " + ShapeColor.Blue); 
        Console.WriteLine("Thickness= " + Thickness);
       
      
    }
}