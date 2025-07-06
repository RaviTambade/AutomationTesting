//Common Type System
//1.Value Types
// int, float, double, decimal, bool, enum, char
// values are stored on stack
//2.Refernce Types
// class, interface ,delegate, event
//values are stored on heap

using Maths;
public class Program
{
    //Member variable 
    private string name = String.Empty;
    private string description = String.Empty;
    private string author = string.Empty;
    //class function (shared function) (static function)
    public static void Main(string[] args)
    {
        //Value types (Primitive types)
        /* char c = 'A';
         bool status = false;
         int age = 49;   //local variable
         */
        Program theProgram = new Program();
        theProgram.name = "ECommerce Program";
        theProgram.description = "This is a simple Program instance";
        theProgram.author = "Ravi Tambade";

        Console.WriteLine("Hello World");
        Console.WriteLine(theProgram.name);
        Console.WriteLine(theProgram.description);
        Console.WriteLine(theProgram.author);

        Complex c1 = new Complex();
        //Assign value
        c1.SetReal(56);
        c1.SetImaginary(100);

       //Retrive value
        Console.WriteLine(c1.GetReal() );
        Console.WriteLine(c1.GetImaginary());
            
    }
}
