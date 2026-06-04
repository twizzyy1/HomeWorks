using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace UserOrderManager
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Product { get; set; }
        public decimal Amount { get; set; }
    }

    public class DataManager
    {
        private const string UsersFile = "users.json";
        private const string OrdersFile = "orders.json";

        public List<User> Users { get; set; }
        public List<Order> Orders { get; set; }

        public DataManager()
        {
            LoadData();
        }

        private void LoadData()
        {
            Users = LoadFromFile<List<User>>(UsersFile) ?? new List<User>();
            Orders = LoadFromFile<List<Order>>(OrdersFile) ?? new List<Order>();
        }

        public void SaveData()
        {
            SaveToFile(UsersFile, Users);
            SaveToFile(OrdersFile, Orders);
        }

        private T LoadFromFile<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
                return new T();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        private void SaveToFile<T>(string filePath, T data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AddUser(string name, string email)
        {
            int newId = Users.Count > 0 ? Users.Max(u => u.Id) + 1 : 1;
            Users.Add(new User { Id = newId, Name = name, Email = email });
            SaveData();
            Console.WriteLine($"Пользователь '{name}' добавлен с ID = {newId}");
        }

        public bool DeleteUser(int userId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return false;

            Users.Remove(user);
            Orders.RemoveAll(o => o.UserId == userId);
            SaveData();
            Console.WriteLine($"Пользователь '{user.Name}' и его заказы удалены");
            return true;
        }

        public void AddOrder(int userId, string product, decimal amount)
        {
            if (!Users.Any(u => u.Id == userId))
            {
                Console.WriteLine($"Ошибка: пользователь с ID {userId} не существует");
                return;
            }

            int newId = Orders.Count > 0 ? Orders.Max(o => o.Id) + 1 : 1;
            Orders.Add(new Order { Id = newId, UserId = userId, Product = product, Amount = amount });
            SaveData();
            Console.WriteLine($"Заказ '{product}' добавлен для пользователя ID {userId}");
        }

        public bool DeleteOrder(int orderId)
        {
            var order = Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
                return false;

            Orders.Remove(order);
            SaveData();
            Console.WriteLine($"Заказ ID {orderId} удалён");
            return true;
        }

        public void PrintAllUsersWithOrders()
        {
            if (Users.Count == 0)
            {
                Console.WriteLine("Список пользователей пуст.");
                return;
            }

            foreach (var user in Users)
            {
                Console.WriteLine($"\n[Пользователь] ID: {user.Id}, Имя: {user.Name}, Email: {user.Email}");
                var userOrders = Orders.Where(o => o.UserId == user.Id).ToList();
                if (userOrders.Any())
                {
                    Console.WriteLine("  Заказы:");
                    foreach (var order in userOrders)
                    {
                        Console.WriteLine($"    ID: {order.Id}, Товар: {order.Product}, Сумма: {order.Amount:C}");
                    }
                }
                else
                {
                    Console.WriteLine("  Нет заказов.");
                }
            }
        }
    }

    class Program
    {
        static DataManager dataManager = new DataManager();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool running = true;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        DeleteUser();
                        break;
                    case "3":
                        AddOrder();
                        break;
                    case "4":
                        DeleteOrder();
                        break;
                    case "5":
                        dataManager.PrintAllUsersWithOrders();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== Управление пользователями и заказами ===");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Удалить пользователя");
            Console.WriteLine("3. Добавить заказ");
            Console.WriteLine("4. Удалить заказ");
            Console.WriteLine("5. Показать всех пользователей с заказами");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");
        }

        static void AddUser()
        {
            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();
            Console.Write("Введите email: ");
            string email = Console.ReadLine();
            dataManager.AddUser(name, email);
        }

        static void DeleteUser()
        {
            Console.Write("Введите ID пользователя для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (!dataManager.DeleteUser(id))
                    Console.WriteLine($"Пользователь с ID {id} не найден.");
            }
            else
            {
                Console.WriteLine("Неверный ID.");
            }
        }

        static void AddOrder()
        {
            Console.Write("Введите ID пользователя: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Неверный ID.");
                return;
            }
            Console.Write("Введите название товара: ");
            string product = Console.ReadLine();
            Console.Write("Введите сумму заказа: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Неверная сумма.");
                return;
            }
            dataManager.AddOrder(userId, product, amount);
        }

        static void DeleteOrder()
        {
            Console.Write("Введите ID заказа для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (!dataManager.DeleteOrder(id))
                    Console.WriteLine($"Заказ с ID {id} не найден.");
            }
            else
            {
                Console.WriteLine("Неверный ID.");
            }
        }
    }
}





