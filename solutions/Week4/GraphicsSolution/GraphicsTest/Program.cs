
using Drawing;
using HR;

using UI;
public class Program
{
    public static void Main(string[] args)
    {


        /*Color myColor = new Color(255, 0, 0);
        Shape theShape = new Line(startPoint, endPoint, 12, myColor);

        theShape.Draw();*/

        //Menu Driven Program to create Line or Circle

        UIManager mgr = new UIManager();
        mgr.ShowMenu();
        int choice = mgr.GetChoice();

        switch (choice)
        {
            case 1:
              
                break;
            case 2:
            
                break;
            case 3:
                return 0;
                break;
        }








    }
}