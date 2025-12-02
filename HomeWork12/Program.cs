using System;

namespace UniversalCalculator
{
    class Program
    {
        delegate double MathOperation(double a, double b);

        static void Main(string[] args)
        {
            Console.WriteLine("— Универсальный калькулятор —");

            Console.WriteLine("Введите первое число:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n— Результаты вычислений —");

            PerformCalculation(num1, num2, "Сложение", (a, b) => a + b);
            PerformCalculation(num1, num2, "Вычитание", (a, b) => a - b);
            PerformCalculation(num1, num2, "Умножение", (a, b) => a * b);

            PerformCalculation(num1, num2, "Деление", (a, b) =>
            {
                if (b != 0)
                    return a / b;
                else
                {
                    Console.WriteLine("Деление на ноль невозможно!");
                    return double.NaN;
                }
            });

            PerformCalculation(num1, num2, "Остаток от деления", (a, b) => a % b);
            PerformCalculation(num1, num2, "Возведение в степень", Math.Pow);

            Console.ReadKey();
        }

        static void PerformCalculation(double a, double b, string operationName, MathOperation operation)
        {
            try
            {
                double result = operation(a, b);
                if (!double.IsNaN(result))
                {
                    Console.WriteLine($"{operationName}: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{operationName}: Ошибка - {ex.Message}");
            }
        }
    }
}