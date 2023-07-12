public class Furniture
{
    string material;
    double price;

    public void Furnitures()
    {
        Console.WriteLine("Furniture Class");
    }
}
class Table : Furniture
{
    double height;
    string surfaceArea;

    public void Tables()
    {
        Console.WriteLine("Table Class");
    }
}

public class Program
{
    public static void Main(String[] args)
    {
        Table t = new Table();
        t.Furnitures();
        t.Tables();

    }
}