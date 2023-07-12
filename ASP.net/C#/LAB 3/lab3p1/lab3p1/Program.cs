class lab3p1
{
    public static void Main()
    {
        Candidate cn = new Candidate();
        cn.getCandidateDetails();
        cn.DisplayCandidateDetails();
    }
}

class Candidate
{
    int id, age;
    string name;
    double weight, height;

    public void getCandidateDetails()
    {
        Console.WriteLine("Enter Candidate Id : ");
        this.id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Candidate name : ");
        this.name = Console.ReadLine();

        Console.WriteLine("Enter Candidate age : ");
        this.age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter candidate weight : ");
        this.weight = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Candidate height : ");
        this.height = Convert.ToInt32(Console.ReadLine());

    }

    public void DisplayCandidateDetails()
    {
        Console.WriteLine("ID : " + id);
        Console.WriteLine("Name : " + name);
        Console.WriteLine("Age : " +  age);
        Console.WriteLine("Weight : " +  weight);
        Console.WriteLine("Height : " +  height);
    }
}