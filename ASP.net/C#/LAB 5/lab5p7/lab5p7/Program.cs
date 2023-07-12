public delegate void TrafficDel();
public class TrafficSignal

{
    public static void Main(string[] args)
    {
        TrafficDel t1 = new TrafficDel(Yellow);
        TrafficDel t2 = new TrafficDel(Red);
        TrafficDel t3 = new TrafficDel(Green);

        t1.Invoke();
        t2.Invoke();
        t3.Invoke();
    }
    public static void Yellow() 
    { 
        Console.WriteLine("Yellow light signals to get ready");
    }
    public static void Red()
    { 
        Console.WriteLine("Red Light Signal To Stop"); 
    }
    public static void Green()
    { 
        Console.WriteLine("Green Light Signal To Go"); 
    }
}