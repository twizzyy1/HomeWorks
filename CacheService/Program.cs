using System;
using System.Collections.Generic;

public sealed class CacheService
{
    private static CacheService _instance;
    private static readonly object _lock = new object();
    private Dictionary<string, object> _cache;

    private CacheService()
    {
        _cache = new Dictionary<string, object>();
        Console.WriteLine("(Экземпляр CacheService создан)");
    }

    public static CacheService GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new CacheService();
                }
            }
        }
        return _instance;
    }

    public void Add(string key, object value)
    {
        if (_cache.ContainsKey(key))
        {
            _cache[key] = value;
            Console.WriteLine($"Данные '{key}' обновлены.");
        }
        else
        {
            _cache.Add(key, value);
            Console.WriteLine($"Данные '{key}' добавлены.");
        }
    }

    public object Get(string key)
    {
        if (_cache.ContainsKey(key))
        {
            return _cache[key];
        }
        else
        {
            Console.WriteLine($"Ключ '{key}' не найден в кэше.");
            return null;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Демонстрация работы глобального кэша (Singleton) ---");

        CacheService cache1 = CacheService.GetInstance();

        Console.WriteLine("\nДобавляем данные в кэш через первую ссылку...");
        cache1.Add("ConnectionString", "Server=.;Database=CacheDB;");
        cache1.Add("ApiKey", "XYZ12345ABC");

        CacheService cache2 = CacheService.GetInstance();

        Console.WriteLine("\nПолучаем данные из кэша через ВТОРУЮ ссылку...");
        Console.WriteLine($"Значение по ключу 'ConnectionString': {cache2.Get("ConnectionString")}");
        Console.WriteLine($"Значение по ключу 'ApiKey': {cache2.Get("ApiKey")}");

        Console.WriteLine("\nПроверяем, что обе переменные ссылаются на один объект...");
        Console.WriteLine($"Результат: {object.ReferenceEquals(cache1, cache2)}");
    }
}