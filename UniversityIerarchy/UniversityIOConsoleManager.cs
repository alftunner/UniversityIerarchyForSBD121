using System.Reflection;

namespace UniversityIerarchy;

public static class UniversityIOConsoleManager
{
    public static void UniversityInit(University university)
    {
        Console.Write("Введите название университета: ");
        university.NameOfUniversity = Console.ReadLine();
        Console.Write("Введите адрес университета: ");
        university.AddressOfUniversity = Console.ReadLine();
        university.Facultets = new List<string>();
        university.Students = new List<Student>();
        Console.Write("Введите названия факультетов через запятую: ");
        string[] facultetsTemp = Console.ReadLine().Split(",");
        foreach (var item in facultetsTemp)
        {
            university.Facultets.Add(item.Trim());
        }
    }

    public static void PrintUniversityInfo(University university)
    {
        Console.WriteLine($"Университет - {university.NameOfUniversity}");
        Console.WriteLine($"Адрес - {university.AddressOfUniversity}");
        Console.WriteLine("Факультеты:");
        foreach (var item in university.Facultets)
        {
            Console.WriteLine(item);
        }
    }

    public static void StudentInit(University university)
    {
        Console.Write("Введите количество студентов к добавлению:");
        int quantityStudents = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < quantityStudents; i++)
        {
            Student student = new Student();
            Console.Write("Фио студента: ");
            student.FIO = Console.ReadLine();
            Console.Write("Дата рождения студента в формате dd.mm.yyyy: ");
            student.Birthday = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Выберите факультет и введите его порядковый номер: ");
            int counter = 1;
            foreach (var item in university.Facultets)
            {
                Console.WriteLine(counter + ". " + item);
                counter++;
            }

            student.Facultet = university.Facultets[Convert.ToInt32(Console.ReadLine()) - 1];
            Console.Write("Группа студента: ");
            student.Group = Console.ReadLine();
            university.Students.Add(student);
        }
    }

    public static void PrintStudents(University university)
    {
        Console.WriteLine("Список студентов: ");
        foreach (var student in university.Students)
        {
            Console.WriteLine(student.StudentId);
            Console.WriteLine(student.FIO);
            Console.WriteLine(student.Birthday.ToString());
            Console.WriteLine(student.Facultet);
            Console.WriteLine(student.Group);
            Console.WriteLine("-------------------");
        }
    }
    
    public static void PrintStudents(List<Student> students)
    {
        Console.WriteLine("Список студентов: ");
        foreach (var student in students)
        {
            Console.WriteLine(student.StudentId);
            Console.WriteLine(student.FIO);
            Console.WriteLine(student.Birthday.ToString());
            Console.WriteLine(student.Facultet);
            Console.WriteLine(student.Group);
            Console.WriteLine("-------------------");
        }
    }

    public static void findStudenyInfo(University university)
    {
        Console.WriteLine("Будем искать студентов по некоторым параметрам:");
        Console.WriteLine("Введите порядковый номер параметра для поиска из доступных:");
        PropertyInfo[] myPropertyInfo;
        Type type = typeof(Student);
        myPropertyInfo = type.GetProperties();
        int counter = 1;
        foreach (var item in myPropertyInfo)
        {
            Console.WriteLine(counter + ". " + item.Name);
            counter++;
        }

        string propName = myPropertyInfo[Convert.ToInt32(Console.ReadLine()) - 1].Name;

        switch (propName)
        {
            case "Facultet" :
                Console.Write("Введите название факультета:");
                string facultet = Console.ReadLine();
                List<Student> findStudents = new List<Student>();
                foreach (var student in university.Students)
                {
                    if (student.Facultet == facultet)
                    {
                        findStudents.Add(student);
                    }
                }
                PrintStudents(findStudents);
                break;
        }
    }
}