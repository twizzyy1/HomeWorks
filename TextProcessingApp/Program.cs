using System;
using System.Collections.Generic;

namespace TextProcessingApp
{
    public interface ITextPlugin
    {
        string Process(string input);
    }

    public class ToUpperPlugin : ITextPlugin
    {
        public string Process(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return input.ToUpper();
        }
    }

    public class SpaceRemoverPlugin : ITextPlugin
    {
        public string Process(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return input.Replace(" ", "");
        }
    }

    public class ReversePlugin : ITextPlugin
    {
        public string Process(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    public class TextProcessor
    {
        public string ProcessWithPlugins(string input, List<ITextPlugin> plugins)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string result = input;
            foreach (var plugin in plugins)
            {
                result = plugin.Process(result);
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TextProcessor processor = new TextProcessor();

            List<ITextPlugin> plugins = new List<ITextPlugin>
            {
                new ToUpperPlugin(),
                new SpaceRemoverPlugin(),
                new ReversePlugin()
            };

            string originalText = "Привет мир! Это тестовый текст.";

            Console.WriteLine($"Исходный текст: {originalText}");
            Console.WriteLine(new string('-', 50));

            string result = processor.ProcessWithPlugins(originalText, plugins);

            Console.WriteLine($"Результат после всех плагинов: {result}");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("\nПошаговая обработка:");
            string step = originalText;
            foreach (var plugin in plugins)
            {
                step = plugin.Process(step);
                Console.WriteLine($"{plugin.GetType().Name}: \"{step}\"");
            }

            Console.ReadKey();
        }
    }
}