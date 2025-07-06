namespace Maths;

public class Complex
{
    private int real;
    private int imaginary;

    public Complex()   //Default cnstructor
    {
        this.real = 12;
        this.imaginary = 13;
    }
    public void SetReal(int real)
    {
        this.real = real;
    }
    public void SetImaginary(int imaginary)
    {
        this.imaginary = imaginary;
    }

    public int GetReal()
    {
        return this.real;
    }

    public int GetImaginary()
    {
        return this.imaginary;
    }
}