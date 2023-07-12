class lab3p6
{
    public static void Main()
    {
        Console.WriteLine("Enter distance 1 : ");
        double dist1 = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter distance 2 : ");
        double dist2 = double.Parse(Console.ReadLine());

        Distance ds = new Distance(dist1, dist2);
        ds.sum();
        ds.display();
    }
}

class Distance
{
    double dist1, dist2, dist3;

    public Distance(double dist1, double dist2)
    {
        this.dist1 = dist1;
        this.dist2 = dist2;
    }

    public void sum()
    {
        dist3 = dist1 + dist2;
    }

    public void display()
    {
        Console.WriteLine("Answer : " + dist3);
    }
}