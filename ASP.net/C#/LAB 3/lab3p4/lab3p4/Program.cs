class Student_Demo
{
    public static void Main()
    {
        Student st = new Student();
        st.displayStudentsDetails();
    }
}

class Student
{
    long enrollment_no;
    string name;
    int semester;
    double cpi;
    double spi;

    public Student()
    {
        Console.WriteLine("Please enter Enrollment Number : ");
        this.enrollment_no = long.Parse(Console.ReadLine());
        Console.WriteLine("Please enter Student's Name : ");
        this.name = Console.ReadLine();
        Console.WriteLine("Please enter Semester : ");
        this.semester = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter CPI : ");
        this.cpi = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter SPI : ");
        this.spi = double.Parse(Console.ReadLine());
    }

    public void displayStudentsDetails()
    {
        Console.WriteLine("Enrollment Number : " + enrollment_no);
        Console.WriteLine("Student's Name : " + name);
        Console.WriteLine("Semester : " + semester);
        Console.WriteLine("CPI : " + cpi);
        Console.WriteLine("SPI : " + spi);
    }
}
