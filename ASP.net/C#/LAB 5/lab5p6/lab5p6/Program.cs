public delegate int Factorials(int n);

public class Factorial
{
    public static void Main(string[] args)
    {
        Factorials factorial = new Factorials(Fact);
        Console.WriteLine("PLease enter an integer : ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Factorial of {0} is {1}", a, factorial(a));
    }

    public static int Fact(int a)
    {
        int answer = 1;
        for (int i = a; i > 0; i--)
        {
            answer = answer * i;
        }
        return answer;
    }
}