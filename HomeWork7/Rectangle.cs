using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    using System;

    class Rectangle
    {
        public double width;
        public double height;

        public double GetArea()
        {
            return width * height;
        }

        public double GetPerimeter()
        {
            return 2 * (width + height);
        }
    }
    class Program
    {
        static void Main()
        {
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle();

            Console.Write("Введите ширину первого прямоугольника: ");
            rect1.width = double.Parse(Console.ReadLine());

            Console.Write("Введите высоту первого прямоугольника: ");
            rect1.height = double.Parse(Console.ReadLine());

            Console.Write("Введите ширину второго прямоугольника: ");
            rect2.width = double.Parse(Console.ReadLine());

            Console.Write("Введите высоту второго прямоугольника: ");
            rect2.height = double.Parse(Console.ReadLine());

            Console.WriteLine("\nПервый прямоугольник:");
            Console.WriteLine($"Ширина: {rect1.width}");
            Console.WriteLine($"Высота: {rect1.height}");
            Console.WriteLine($"Площадь: {rect1.GetArea()}");
            Console.WriteLine($"Периметр: {rect1.GetPerimeter()}");

            Console.WriteLine("Второй прямоугольник:");
            Console.WriteLine($"Ширина: {rect2.width}");
            Console.WriteLine($"Высота: {rect2.height}");
            Console.WriteLine($"Площадь: {rect2.GetArea()}");
            Console.WriteLine($"Периметр: {rect2.GetPerimeter()}");

            Console.ReadLine();
        }
    }
}