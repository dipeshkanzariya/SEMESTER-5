public class Addition
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    { 
        return a + b; 
    }
}

public class lab5p1
{
    public static void Main(string[] args)
    {
        Addition addition = new Addition();
        Console.WriteLine(addition.Add(1, 2));
        Console.WriteLine(addition.Add(2.4, 3.5));
    }
}