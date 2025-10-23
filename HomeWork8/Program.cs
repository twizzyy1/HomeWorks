using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("-- Калькулятор факториала --");
        Console.WriteLine("Введите число:");

        int number;
        if (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Ошибка! Введите целое число.");
            return;
        }

        if (number < 0)
        {
            Console.WriteLine("Ошибка! Факториал можно вычислить только для неотрицательных чисел.");
            return;
        }

        long result = CalculateFactorial(number);
        Console.WriteLine($"Факториал числа {number} равен {result}");
    }

    static long CalculateFactorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        long factorial = 1;
        for (int i = 2; i <= n; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}