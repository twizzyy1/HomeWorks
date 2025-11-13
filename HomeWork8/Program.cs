using System;

public class Student
{
    private int _age;

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int Age
    {
        get { return _age; }
        set
        {
            if (value >= 6 && value <= 100)
            {
                _age = value;
            }
            else
            {
                Console.WriteLine($"Ошибка: возраст {value} некорректен. Возраст должен быть от 6 до 100 лет.");
            }
        }
    }

    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }

    public Student(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public Student() : this("", "", 0)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Тестирование класса Student ===");

        Student student1 = new Student("Иван", "Петров", 20);
        Console.WriteLine($"Студент: {student1.FullName}, Возраст: {student1.Age}");

        Student student2 = new Student("Мария", "Иванова", 5);
        Console.WriteLine($"Студент: {student2.FullName}, Возраст: {student2.Age}");

        Student student3 = new Student("Алексей", "Сидоров", 150);
        Console.WriteLine($"Студент: {student3.FullName}, Возраст: {student3.Age}");

        Console.WriteLine("\nПопытка изменить возраст студента Ивана на 200:");
        student1.Age = 200;
        Console.WriteLine($"Текущий возраст: {student1.Age}");

        Console.WriteLine("\nКорректное изменение возраста студента Ивана:");
        student1.Age = 25;
        Console.WriteLine($"Текущий возраст: {student1.Age}");

        Student student4 = new Student();
        student4.FirstName = "Анна";
        student4.LastName = "Козлова";
        student4.Age = 19;
        Console.WriteLine($"\nНовый студент: {student4.FullName}, Возраст: {student4.Age}");

        Console.WriteLine("\nТестирование завершено!");
    }
}