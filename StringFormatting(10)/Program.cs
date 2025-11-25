using System;
using System.Text;

namespace StringFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Форматирование списка пользователей ---\n");

            string inputString = "  иванов иван,петров петр, сидорова Анна, бобров БОРИС  ";

            Console.WriteLine($"Исходная строка: \"{inputString}\"\n");

            string formattedList = FormatUserList(inputString);

            Console.WriteLine("Отформатированный список:");
            Console.WriteLine(formattedList);

            Console.ReadKey();
        }

        static string FormatUserList(string input)
        { 

            string cleanedInput = input.Trim();
            string[] namePairs = cleanedInput.Split(',');

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < namePairs.Length; i++)
            {
                string cleanedPair = namePairs[i].Trim();

                string[] parts = cleanedPair.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2)
                {
                    string lastName = FormatName(parts[0]);

                    string firstName = FormatName(parts[1]);

                    result.AppendLine($"{i + 1}. {lastName} {firstName}");
                }
            }

            return result.ToString();
        }

        static string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            string lowerCaseName = name.ToLower();

            return char.ToUpper(lowerCaseName[0]) + lowerCaseName.Substring(1);
        }
    }
}