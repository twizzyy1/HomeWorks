using System;
using System.IO;

class OrderValidator
{
    public bool Validate(string itemName, int quantity)
    {
        if (string.IsNullOrEmpty(itemName))
        {
            Console.WriteLine("Ошибка: Название товара не может быть пустым.");
            return false;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("Ошибка: Количество должно быть больше нуля.");
            return false;
        }

        Console.WriteLine("Заказ прошел валидацию.");
        return true;
    }
}

class OrderRepository
{
    public void Save(string itemName, int quantity)
    {
        File.WriteAllText("order.txt",
            $"Товар: {itemName}, Количество: {quantity}");

        Console.WriteLine("Заказ сохранен в файл.");
    }
}

class NotificationService
{
    public void SendNotification()
    {
        Console.WriteLine("Отправка email-уведомления: 'Ваш заказ принят'.");
    }
}

class OrderProcessor
{
    private OrderValidator validator;
    private OrderRepository repository;
    private NotificationService notificationService;

    public OrderProcessor()
    {
        validator = new OrderValidator();
        repository = new OrderRepository();
        notificationService = new NotificationService();
    }

    public void ProcessOrder(string itemName, int quantity)
    {
        if (!validator.Validate(itemName, quantity))
        {
            return;
        }

        repository.Save(itemName, quantity);

        notificationService.SendNotification();
    }
}

class Program
{
    static void Main()
    {
        OrderProcessor processor = new OrderProcessor();

        Console.WriteLine("--- Обработка нового заказа ---");

        string item1 = "Ноутбук";
        int quantity1 = 2;

        Console.WriteLine($"Введите название товара: {item1}");
        Console.WriteLine($"Введите количество: {quantity1}");

        processor.ProcessOrder(item1, quantity1);

        Console.WriteLine();

        Console.WriteLine("--- Попытка обработки некорректного заказа ---");

        string item2 = "";
        int quantity2 = -5;

        Console.WriteLine("Введите название товара:");
        Console.WriteLine($"Введите количество: {quantity2}");

        processor.ProcessOrder(item2, quantity2);
    }
}