
using Drawing;
using HR;

using UI;
public class Program
{
    public static void Main(string[] args)
    {

        Point startPoint = new Point(34, 56);
        Point endPoint = new Point(87, 34);

        Color myColor = new Color(255, 0, 0);
        Shape theShape = new Line(startPoint, endPoint, 12, myColor);
        theShape.Draw();
    }
}