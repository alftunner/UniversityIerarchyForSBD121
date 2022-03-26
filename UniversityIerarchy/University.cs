namespace UniversityIerarchy;

public class University
{
    public string NameOfUniversity { get; set; }
    public string AddressOfUniversity { get; set; }
    public List<string> Facultets { get; set; }
    public List<Student> Students { get; set; }

    public University()
    {
        UniversityIOConsoleManager.UniversityInit(this);
    }

    public void PrintInfo()
    {
        UniversityIOConsoleManager.PrintUniversityInfo(this);
        UniversityIOConsoleManager.PrintStudents(this);
    }

    public void StudentsInit()
    {
        UniversityIOConsoleManager.StudentInit(this);
    }
}