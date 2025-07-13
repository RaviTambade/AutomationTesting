namespace Drawing;

public struct Color
{
    public int Red{get;set;}
    public int Green{get;set;}
    public int Blue{get;set;}

    public Color(int r,int g,int b)
    {
        this.Red=r;
        this.Green=g;
        this.Blue=b;
    }
}