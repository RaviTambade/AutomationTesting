namespace Drawing;

public class Line : Shape
{
   public Point StartPoint { get; set; }
   public Point EndPoint { get; set; }

   public Line()
   {
   }

   public Line(Point startPoint, Point endPoint, int thickness, Color color) : base(thickness, color)
   {
      this.StartPoint = startPoint;
      this.EndPoint = endPoint;
   }
   public void DisplayLine()
   {
      Console.WriteLine("Line Details");
      this.StartPoint.Display();
      this.EndPoint.Display();
   }

   public override void Draw()
   {
      Console.WriteLine("LineDrawFucntion");
      StartPoint.Display();
      EndPoint.Display();
      base.Draw();
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

}