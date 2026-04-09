using System;
using System.Collections.Generic;

abstract class Document
{
    public string Author { get; set; }

    public Document(string author)
    {
        Author = author;
    }

    public abstract void Render();
}

class TextDocument : Document
{
    public string Content { get; set; }

    public TextDocument(string author, string content) : base(author)
    {
        Content = content;
    }

    public override void Render()
    {
        Console.WriteLine($"=== Текстовый документ ===");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Содержимое: {Content}");
        Console.WriteLine();
    }
}

class ImageDocument : Document
{
    public string Resolution { get; set; }

    public ImageDocument(string author, string resolution) : base(author)
    {
        Resolution = resolution;
    }

    public override void Render()
    {
        Console.WriteLine($"=== Изображение ===");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Рендеринг изображения с разрешением: {Resolution}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Document> documents = new List<Document>();

        documents.Add(new TextDocument("Иван Петров", "Это содержимое текстового документа. Здесь может быть любой текст."));
        documents.Add(new ImageDocument("Анна Сидорова", "1920x1080"));
        documents.Add(new TextDocument("Мария Иванова", "Второй текстовый документ для демонстрации полиморфизма."));
        documents.Add(new ImageDocument("Петр Смирнов", "3840x2160"));
        documents.Add(new TextDocument("Елена Козлова", "Краткое описание проекта."));
        documents.Add(new ImageDocument("Дмитрий Николаев", "1024x768"));

        Console.WriteLine("=== Рендеринг документов ===\n");

        foreach (Document doc in documents)
        {
            doc.Render();
        }

        Console.WriteLine("Рендеринг завершен. Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}