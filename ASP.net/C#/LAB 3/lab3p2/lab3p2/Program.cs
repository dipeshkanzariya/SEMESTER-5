class lab3p2
{
    public static void Main()
    {
        Console.WriteLine("Enter the number of staff members which you want to add : ");
        int n = Convert.ToInt32 (Console.ReadLine());

        Staff[] st = new Staff[n];

        for (int i = 0; i < n; i++)
        {
            st[i] = new Staff();
            Console.WriteLine("Enter the name : ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter department : ");
            string department = Console.ReadLine();

            Console.WriteLine("Enter designation : ");
            string designation = Console.ReadLine();

            Console.WriteLine("Enter experience : ");
            int experience = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Salary : ");
            int salary = Convert.ToInt32(Console.ReadLine());

            st[i].setData(name, department, designation, experience, salary);

        }

        for(int i = 0; i < n;i++)
        {
            if(st[i].designation == "HOD" || st[i].designation == "hod" )
            {
                st[i].displayData();
            }
        }
    }

}

class Staff
{
    public string name, department, designation;
    int experience,salary;

    public void setData(string name,string department,string designation,int experience,int salary)
    {
        this.name = name;
        this.department = department;
        this.designation = designation;
        this.experience = experience;
        this.salary = salary;
    }

    public void displayData()
    {
        Console.WriteLine("Name : " + name);
        Console.WriteLine("Salary : " + salary);
    }
}