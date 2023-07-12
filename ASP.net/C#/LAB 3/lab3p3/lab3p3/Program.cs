class lab3p3
{
    public static void Main()
    {
        Bank_Account bb = new Bank_Account();
        bb.getAccountDetails();
        bb.displayAccountDetails();
    }
}

class Bank_Account
{
    int Acc_no;
    string email;
    string username;
    string accounttype;
    double accountbalance;

    public void getAccountDetails()
    {
        Console.WriteLine("Please enter Account number : ");
        this.Acc_no = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter Email : ");
        this.email = Console.ReadLine();
        Console.WriteLine("Please enter Username : ");
        this.username = Console.ReadLine();
        Console.WriteLine("Please enter Account type : ");
        this.accounttype = Console.ReadLine();
        Console.WriteLine("Please enter Account balance : ");
        this.accountbalance = double.Parse(Console.ReadLine());
    }

    public void displayAccountDetails()
    {
        Console.WriteLine("Account number : {0}", Acc_no);
        Console.WriteLine("Email : {0}", email);
        Console.WriteLine("Username : {0}", username);
        Console.WriteLine("Account type : {0}", accounttype);
        Console.WriteLine("Account balance : {0}", accountbalance);
    }
}
