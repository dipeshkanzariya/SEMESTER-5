public class AreaOfRectangle
{
    double length;
    double breadth;

    public AreaOfRectangle(double length, double breadth)
    {
        this.length = length;
        this.breadth = breadth;
    }

    double CalculateArea()
    {

        return this.length * this.breadth;
    }

    public static void Main(String[] args)
    {

        Console.Write("Please enter lenght : ");
        double length = double.Parse(Console.ReadLine());

        Console.Write("Please enter breadth : ");
        double breadth = double.Parse(Console.ReadLine());

        AreaOfRectangle r = new AreaOfRectangle(length, breadth);

        Console.WriteLine("Area of Rectangel is : " + r.CalculateArea());

    }
}