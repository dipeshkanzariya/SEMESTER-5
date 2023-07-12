public class Area
{
    public double AreaOfShape(double x)
    {
        return x * x;
    }

    public double AreaOfShape(double l, double b)
    {
        return l * b;
    }
}

public class lab5p2
{
    public static void Main()
    {
        Area area = new Area();
        Console.WriteLine(area.AreaOfShape(10));
        Console.WriteLine(area.AreaOfShape(3, 4));
    }
}