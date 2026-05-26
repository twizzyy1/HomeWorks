using System;

public interface ILogger
{
    void Log(string message);
}

public class OldLogger
{

    public void LogMessage(string message, DateTime date)
    {
        Console.WriteLine($"[OLD LOGGER] {date:yyyy-MM-dd HH:mm:ss} - {message}");
    }
}

public class LoggerAdapter : ILogger
{
    private readonly OldLogger _oldLogger;

    public LoggerAdapter(OldLogger oldLogger)
    {
        _oldLogger = oldLogger;
    }

    public void Log(string message)
    {

        _oldLogger.LogMessage(message, DateTime.Now);
    }
}

class Program
{
    static void Main()
    {
        OldLogger oldLogger = new OldLogger();

        ILogger logger = new LoggerAdapter(oldLogger);

        logger.Log("пользователь вошёл в систему");
        logger.Log("загружены настройки приложения");
        logger.Log("приложение завершает работу");

        Console.WriteLine("\nработа адаптера завершена.");
    }
}