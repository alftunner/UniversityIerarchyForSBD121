namespace UniversityIerarchy;

public class Student
{
    public static int id = 0;
    public string FIO { get; set; }
    public int StudentId { get; set; }
    public DateTime Birthday { get; set; }
    public string Facultet { get; set; }
    public string Group { get; set; }

    public Student()
    {
        id++;
        this.StudentId = id;
    }
}