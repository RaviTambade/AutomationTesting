using Drawing;
using UI;
public class Program
{
    public static int Main(string[] args)
    {
        while (true)
        {
            UIManager mgr = new UIManager();
            mgr.ShowMenu();
            int choice = mgr.GetChoice();
            switch (choice)
            {
                case 1:
                    {
                        Line l1 = mgr.GetLine();
                        l1.Draw();
                    }
                    break;
                case 2:
                    {
                        //Cirlcle c1 = mgr.GetCircle();
                    }
                    break;

                case 3:
                    return 0;
                    break;
            }
        }

 
    }
}