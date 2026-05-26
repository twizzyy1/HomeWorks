using System;

public interface IMessageSender
{
    void Send(string message);
}

public class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка по email: {message}");
    }
}

public class SmsSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка по sms: {message}");
    }
}

public abstract class NotificationServiceFactory
{
    public abstract IMessageSender CreateSender();
}

public class EmailNotificationFactory : NotificationServiceFactory
{
    public override IMessageSender CreateSender()
    {
        return new EmailSender();
    }
}

public class SmsNotificationFactory : NotificationServiceFactory
{
    public override IMessageSender CreateSender()
    {
        return new SmsSender();
    }
}

public class NotificationService
{
    private readonly NotificationServiceFactory _factory;

    public NotificationService(NotificationServiceFactory factory)
    {
        _factory = factory;
    }

    public void SendNotification(string message)
    {
        IMessageSender sender = _factory.CreateSender();
        sender.Send(message);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== система отправки уведов ===");

        NotificationServiceFactory emailFactory = new EmailNotificationFactory();
        NotificationService emailService = new NotificationService(emailFactory);
        emailService.SendNotification("пр не пиши сюда больше");

        NotificationServiceFactory smsFactory = new SmsNotificationFactory();
        NotificationService smsService = new NotificationService(smsFactory);
        smsService.SendNotification("ваш сногшибательный код подтверждения: 1488_676767");

        Console.WriteLine("\nготово. нажмите ченить для выхода...");
        Console.ReadKey();
    }
}