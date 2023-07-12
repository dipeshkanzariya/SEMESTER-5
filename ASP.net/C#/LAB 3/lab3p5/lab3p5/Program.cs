public class lab3p5
{
    public static void Main()
    {
        Salary salary = new Salary();
        Salary salary2 = new Salary();
    }
}

class Salary
{
    double basic;
    double ta;
    double da;
    double hra;
    double gs;
    public Salary()
    {
        Console.WriteLine("Please enter basic salary : ");
        this.basic = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter TA  : ");
        this.ta = double.Parse(Console.ReadLine());
        hra = basic * (20 / 100.00);
        da = basic * (40 / 100.00);
        gs = basic + ta +( basic * hra )+ (da * basic);
        Console.WriteLine("Gross Salary : " + Math.Round(gs, 4) + " Rs");
    }
}