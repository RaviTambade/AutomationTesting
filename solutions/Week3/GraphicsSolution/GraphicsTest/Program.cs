
using Drawing;
using HR;
public class Program
{
    public static void Main(string[] args)
    {
        Point startPoint = new Point(23, 56);
        Point endPoint = new Point(78, 12);
        Point center = new Point(12, 12);


        Circle crl1 = new Circle(25, center);
        crl1.Display();
        Circle crl2 = new Circle(19, new Point(67, 67));
        crl2.Display();

        Circle crl3 = new Circle(13, new Point(6, 56));
        crl3.Display();

        Circle crl4 = new Circle(5, new Point(98, 7));
        crl4.Display();

        Line l1 = new Line(startPoint, endPoint);
        l1.Display();


        Date joinDate1 = new Date(12, 3, 2024);
        Employee employee1 = new Employee("Bhupendra", "Walhekar", joinDate1);
        employee1.Display();

        Date joinDate2 = new Date(21, 12, 1997);
        Employee employee2 = new Employee("Ravi", "Tambade", joinDate2);
        employee2.Display();
        

    }
}