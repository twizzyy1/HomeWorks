using System;

namespace ImprovedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCalculator();
        }

        /// <summary>
        /// Основной метод, запускающий калькулятор
        /// </summary>
        static void RunCalculator()
        {
            DisplayWelcomeMessage();

            double firstNumber = GetNumberFromUser("Введите первое число: ");
            double secondNumber = GetNumberFromUser("Введите второе число: ");
            char operation = GetOperationFromUser();

            double result = Calculate(firstNumber, secondNumber, operation);

            DisplayResult(firstNumber, secondNumber, operation, result);
        }

        /// <summary>
        /// Отображает приветственное сообщение и доступные операции
        /// </summary>
        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("— Улучшенный калькулятор —");
            Console.WriteLine("Доступные операции: +, -, *, /");
            Console.WriteLine();
        }

        /// <summary>
        /// Получает число от пользователя
        /// </summary>
        /// <param name="prompt">Сообщение для пользователя</param>
        /// <returns>Введенное число</returns>
        static double GetNumberFromUser(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите корректное число!");
                }
            }
        }

        /// <summary>
        /// Получает операцию от пользователя
        /// </summary>
        /// <returns>Символ операции</returns>
        static char GetOperationFromUser()
        {
            char operation;
            while (true)
            {
                Console.Write("Введите символ операции: ");
                if (char.TryParse(Console.ReadLine(), out operation) &&
                    IsValidOperation(operation))
                {
                    return operation;
                }
                else
                {
                    Console.WriteLine("Ошибка: Неподдерживаемая операция! Доступные операции: +, -, *, /");
                }
            }
        }

        /// <summary>
        /// Проверяет, является ли операция допустимой
        /// </summary>
        /// <param name="operation">Символ операции</param>
        /// <returns>true если операция допустима, иначе false</returns>
        static bool IsValidOperation(char operation)
        {
            return operation == '+' || operation == '-' || operation == '*' || operation == '/';
        }

        /// <summary>
        /// Выполняет математическую операцию
        /// </summary>
        /// <param name="firstNumber">Первое число</param>
        /// <param name="secondNumber">Второе число</param>
        /// <param name="operation">Символ операции</param>
        /// <returns>Результат вычисления</returns>
        static double Calculate(double firstNumber, double secondNumber, char operation)
        {
            switch (operation)
            {
                case '+':
                    return firstNumber + secondNumber;
                case '-':
                    return firstNumber - secondNumber;
                case '*':
                    return firstNumber * secondNumber;
                case '/':
                    if (secondNumber == 0)
                    {
                        Console.WriteLine("Ошибка: Деление на ноль!");
                        Environment.Exit(1);
                    }
                    return firstNumber / secondNumber;
                default:
                    Console.WriteLine("Ошибка: Неподдерживаемая операция!");
                    Environment.Exit(1);
                    return 0;
            }
        }

        /// <summary>
        /// Отображает результат вычисления
        /// </summary>
        /// <param name="firstNumber">Первое число</param>
        /// <param name="secondNumber">Второе число</param>
        /// <param name="operation">Символ операции</param>
        /// <param name="result">Результат вычисления</param>
        static void DisplayResult(double firstNumber, double secondNumber, char operation, double result)
        {
            Console.WriteLine();
            Console.WriteLine($"Результат: {firstNumber} {operation} {secondNumber} = {result}");
        }
    }
}
