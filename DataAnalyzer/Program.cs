using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DataProcessingApp
{
    public abstract class DataProcessor
    {
        public void Process()
        {
            string rawData = ReadData();
            var parsedData = ParseData(rawData);
            AnalyzeData(parsedData);
            SaveReport(parsedData);
        }

        protected abstract string ReadData();
        protected abstract List<Dictionary<string, string>> ParseData(string rawData);

        protected virtual void AnalyzeData(List<Dictionary<string, string>> data)
        {
            int recordCount = data.Count;
            Console.WriteLine($"Анализ: найдено {recordCount} записей.");
        }

        protected virtual void SaveReport(List<Dictionary<string, string>> data)
        {
            Console.WriteLine("Сохранение отчёта в консоль:");
            foreach (var record in data)
            {
                foreach (var kvp in record)
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
                Console.WriteLine("---");
            }
        }
    }

    public class CsvDataProcessor : DataProcessor
    {
        private readonly string _csvData;

        public CsvDataProcessor(string csvData)
        {
            _csvData = csvData;
        }

        protected override string ReadData()
        {
            Console.WriteLine("[CSV] Чтение данных из строки...");
            return _csvData;
        }

        protected override List<Dictionary<string, string>> ParseData(string rawData)
        {
            Console.WriteLine("[CSV] Парсинг CSV данных...");
            var result = new List<Dictionary<string, string>>();

            var lines = rawData.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0) return result;

            var headers = lines[0].Split(',');
            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var record = new Dictionary<string, string>();
                for (int j = 0; j < headers.Length && j < values.Length; j++)
                {
                    record[headers[j]] = values[j];
                }
                result.Add(record);
            }
            return result;
        }
    }

    public class XmlDataProcessor : DataProcessor
    {
        private readonly string _xmlData;

        public XmlDataProcessor(string xmlData)
        {
            _xmlData = xmlData;
        }

        protected override string ReadData()
        {
            Console.WriteLine("[XML] Чтение данных из строки...");
            return _xmlData;
        }

        protected override List<Dictionary<string, string>> ParseData(string rawData)
        {
            Console.WriteLine("[XML] Парсинг XML данных...");
            var result = new List<Dictionary<string, string>>();

            try
            {
                var doc = XDocument.Parse(rawData);
                var root = doc.Root;
                if (root == null) return result;

                foreach (var item in root.Elements("item"))
                {
                    var record = new Dictionary<string, string>();
                    foreach (var element in item.Elements())
                    {
                        record[element.Name.LocalName] = element.Value;
                    }
                    result.Add(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка парсинга XML: {ex.Message}");
            }

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string csvSample = "Name,Age,City\nAlice,30,Moscow\nBob,25,St.Petersburg";

            string xmlSample = @"<data>
                                    <item><Name>Charlie</Name><Age>35</Age><City>Kazan</City></item>
                                    <item><Name>Diana</Name><Age>28</Age><City>Novosibirsk</City></item>
                                </data>";

            DataProcessor processor1 = new CsvDataProcessor(csvSample);
            DataProcessor processor2 = new XmlDataProcessor(xmlSample);

            Console.WriteLine("=== Обработка CSV ===");
            processor1.Process();

            Console.WriteLine("\n=== Обработка XML ===");
            processor2.Process();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}