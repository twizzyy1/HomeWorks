using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugaday_chislo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество попыток: ");
            int maxAttempts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Возможное количество попыток: {maxAttempts}");

            char again = 'y';
            Random rand = new Random();

            while (again == 'y')
            {
                int secretNumber = rand.Next(100);
                Console.WriteLine("Компьютер загадал число от 0 до 100");

                if (secretNumber < 50)
                    Console.WriteLine("Число меньше 50");
                else
                    Console.WriteLine("Число больше или равно 50");

                bool guessed = false;
                int attempts = 0;;

                while (!guessed && attempts < maxAttempts)
                {
                    attempts++;
                    Console.Write($"Попытка {attempts}/{maxAttempts}. Введите число: ");
                    int userGuess = Convert.ToInt32(Console.ReadLine());

                    if (secretNumber == userGuess)
                    {
                        Console.WriteLine($"Поздравляем! Вы угадали число с {attempts} попытки!");
                        guessed = true;
                    }
                    else
                    {
                        if (attempts < maxAttempts)
                        {
                            if (userGuess < secretNumber)
                                Console.WriteLine("Загаданное число БОЛЬШЕ");
                            else
                                Console.WriteLine("Загаданное число МЕНЬШЕ");
                        }
                    }
                }

                if (!guessed)
                {
                    Console.WriteLine($"Вы исчерпали все попытки! Компьютер загадал число {secretNumber}");
                }

                Console.WriteLine("Попробовать еще? (y = Да, n = Нет)");
                again = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
