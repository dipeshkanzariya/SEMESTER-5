public class Areas
{
    public double Area(double x)
    {
        return Math.PI * x * x;
    }

    public double Area(int x)
    {
        return x * x;
    }

    public double Area(double l, double b)
    {
        return l * b;
    }
}

public class lab5p3
{
    public static void Main()
    {
        Areas area = new Areas();
        Console.WriteLine("Area of circle : {0}", area.Area(4));
        Console.WriteLine("Area of Square : {0}", area.Area(10));
        Console.WriteLine("Area of Rectangle : {0}", area.Area(3, 4));
    }
}