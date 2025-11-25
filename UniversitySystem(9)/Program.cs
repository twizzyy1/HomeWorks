using System;

namespace UniversitySystem
{
    public struct Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"\"{Title}\" автора {Author}";
        }
    }

    public class Student
    {
        private static int _studentCount = 0;

        public string Name { get; set; }
        public Book FavoriteBook { get; set; }

        public static int StudentCount
        {
            get { return _studentCount; }
        }

        public Student(string name, Book favoriteBook)
        {
            Name = name;
            FavoriteBook = favoriteBook;
            _studentCount++; 
        }

        public override string ToString()
        {
            return $"{Name}, его любимая книга: {FavoriteBook}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### Система учета студентов ###\n");

            Console.WriteLine($"Начальное количество студентов в системе: {Student.StudentCount}\n");

            Book book1 = new Book("Хоббит", "Дж. Р. Р. Толкин");
            Student student1 = new Student("Иван", book1);
            Console.WriteLine($"Создан студент {student1.Name}.");
            Console.WriteLine($"Текущее количество студентов в системе: {Student.StudentCount}\n");

            Book book2 = new Book("Преступление и наказание", "Ф. М. Достоевский");
            Student student2 = new Student("Анна", book2);
            Console.WriteLine($"Создан студент {student2.Name}.");
            Console.WriteLine($"Текущее количество студентов в системе: {Student.StudentCount}\n");

            Console.WriteLine("---\n");

            Console.WriteLine("### Эксперимент с копированием ###\n");

            Console.WriteLine($"Оригинальный студент: {student1}\n");

            Console.WriteLine("...Копируем данные и вносим изменения...");

            Student studentCopy = student1;

            Book bookCopy = student1.FavoriteBook;

            Console.WriteLine("Изменяем имя у копии студента на \"Петр\".");
            Console.WriteLine("Изменяем название у копии книги на 'Властелин Колец'.\n");

            studentCopy.Name = "Петр";
            bookCopy.Title = "Властелин Колец";

            Console.WriteLine("Результат после изменений:");
            Console.WriteLine($"Имя оригинального студента (student1): {student1.Name}");
            Console.WriteLine($"Название любимой книги оригинального студента (student1.FavoriteBook.Title): {student1.FavoriteBook.Title}\n");

            Console.WriteLine("Вывод: Имя студента изменилось, так как классы копируются по ссылке " +
                            "(обе переменные указывают на один и тот же объект в памяти).");
            Console.WriteLine("Вывод: Книга не изменилась, так как структуры копируются по значению " +
                            "(создается новая независимая копия структуры).");

            Console.WriteLine("\n---");
            Console.WriteLine($"Общее количество студентов остается: {Student.StudentCount}");

            Console.ReadKey();
        }
    }
}