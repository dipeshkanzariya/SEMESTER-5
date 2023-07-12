public class RBI
{
    public virtual void CalculateInterest()
    {
        Console.WriteLine("Interest calculated from RBI bank");
    }
}

public class HDFC : RBI
{
    public override void CalculateInterest()
    {
        Console.WriteLine("Interest calculated from HDFC bank");
    }
}

public class SBI : RBI
{
    public override void CalculateInterest()
    {
        Console.WriteLine("Interest calculated from SBI bank");
    }
}

public class ICIC : RBI
{
    public override void CalculateInterest()
    {
        Console.WriteLine("Interest calculated from ICIC bank");
    }
}

public class lab5p4
{
    public static void Main(string[] args)
    {
        RBI r = new RBI();
        r.CalculateInterest();

        HDFC h = new HDFC();
        h.CalculateInterest();

        SBI s = new SBI();
        s.CalculateInterest();

        ICIC i = new ICIC();
        i.CalculateInterest();
    }
}