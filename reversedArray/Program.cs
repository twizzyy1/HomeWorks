using System;

namespace ArrayReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] originalArray = { 10, 20, 30, 40, 50 };

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < originalArray.Length; i++)
            {
                Console.WriteLine(originalArray[i] + " ");
            }

            int[] reversedArray = new int[originalArray.Length];

            for (int i = 0; i < originalArray.Length; i++)
            {
                reversedArray[i] = originalArray[originalArray.Length - 1 - i];
            }

            Console.WriteLine("Перевернутый массив: ");
            for (int i = 0; i < reversedArray.Length; i++)
            {
                Console.WriteLine(reversedArray[i] + " ");
            }

            Console.WriteLine();
        }
    }
}