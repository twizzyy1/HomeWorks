class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Age { get; set; }
    public double AverageScore { get; set; }

    public string FullName => $"{LastName} {FirstName}";
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { LastName = "Петров", FirstName = "Иван", Age = 20, AverageScore = 85.5 },
            new Student { LastName = "Сидорова", FirstName = "Анна", Age = 23, AverageScore = 78.1 },
            new Student { LastName = "Кузнецов", FirstName = "Олег", Age = 19, AverageScore = 74.9 },
            new Student { LastName = "Васильева", FirstName = "Мария", Age = 26, AverageScore = 88.3 },
            new Student { LastName = "Смирнов", FirstName = "Алексей", Age = 22, AverageScore = 95.2 }
        };


        Console.WriteLine("--- Список студентов-хорошистов (балл от 75 до 90) ---");
        var goodStudents = students
            .Where(s => s.AverageScore >= 75 && s.AverageScore <= 90)
            .Select(s => new { s.FullName, s.AverageScore });

        foreach (var student in goodStudents)
        {
            Console.WriteLine($"{student.FullName} - {student.AverageScore:F1}");
        }

        Console.WriteLine("\n--- Все студенты ---");
        var names = students.Select(s => s.FullName);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n--- Сортировка по возрасту ---");
        var sortedByAge = students
            .OrderBy(s => s.Age)
            .Select(s => new { s.FullName, s.Age });

        foreach (var student in sortedByAge)
        {
            Console.WriteLine($"{student.FullName} - {student.Age} {GetAgeWord(student.Age)}");
        }

        Console.WriteLine("\n--- Рейтинг студентов младше 25 лет (по убыванию балла) ---");
        var rating = students
            .Where(s => s.Age < 25)
            .OrderByDescending(s => s.AverageScore)
            .Select(s => new { s.FullName, s.AverageScore });

        foreach (var student in rating)
        {
            Console.WriteLine($"{student.FullName} - {student.AverageScore:F1}");
        }

        Console.WriteLine("\nРезультат работы:");
        Console.WriteLine("Сохраните проект целиком, упакуйте проект в архив в формате .zip и прикрепите его дневник Journal на проверку.");
    }

    static string GetAgeWord(int age)
    {
        if (age % 10 == 1 && age % 100 != 11)
            return "год";
        else if (age % 10 >= 2 && age % 10 <= 4 && (age % 100 < 10 || age % 100 >= 20))
            return "года";
        else
            return "лет";
    }
}
