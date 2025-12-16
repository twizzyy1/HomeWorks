using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseInventory
{
    public record Product(int Id, string Name, decimal Price)
    {
        public override string ToString() => $"ID: {Id}, Название: {Name}, Цена: {Price:C}";
    }

    public class Inventory
    {
        private readonly List<Product> _products = new();

        public int ProductCount => _products.Count;

        public bool AddProduct(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Товар не может быть null");
            }

            if (_products.Any(p => p.Id == product.Id))
            {
                Console.WriteLine($"Товар с ID {product.Id} уже существует в инвентаре.");
                return false;
            }

            _products.Add(product);
            Console.WriteLine($"Товар '{product.Name}' успешно добавлен.");
            return true;
        }

        public Product FindProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return _products.AsReadOnly();
        }

        public bool RemoveProduct(int id)
        {
            var product = FindProductById(id);
            if (product is null)
            {
                Console.WriteLine($"Товар с ID {id} не найден.");
                return false;
            }

            _products.Remove(product);
            Console.WriteLine($"Товар '{product.Name}' успешно удален.");
            return true;
        }

        public decimal CalculateTotalValue()
        {
            return _products.Sum(p => p.Price);
        }

        public void DisplayAllProducts()
        {
            Console.WriteLine("\n=== ТЕКУЩИЙ ИНВЕНТАРЬ ===");

            if (_products.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст.");
                return;
            }

            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine($"\nВсего товаров: {ProductCount}");
            Console.WriteLine($"Общая стоимость: {CalculateTotalValue():C}");
            Console.WriteLine("=========================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== СИСТЕМА УЧЕТА ТОВАРОВ НА СКЛАДЕ ===\n");

            var inventory = new Inventory();

            Console.WriteLine("Добавление товаров...");

            var product1 = new Product(101, "Ноутбук Lenovo", 45000.99m);
            var product2 = new Product(102, "Монитор Samsung", 15000.50m);
            var product3 = new Product(103, "Клавиатура Logitech", 2500.00m);
            var product4 = new Product(104, "Мышь беспроводная", 1200.75m);

            inventory.AddProduct(product1);
            inventory.AddProduct(product2);
            inventory.AddProduct(product3);
            inventory.AddProduct(product4);

            var duplicateProduct = new Product(101, "Планшет", 20000.00m);
            inventory.AddProduct(duplicateProduct);

            inventory.DisplayAllProducts();

            Console.WriteLine("Поиск товаров по ID...");

            int searchId = 102;
            var foundProduct = inventory.FindProductById(searchId);

            if (foundProduct is not null)
            {
                Console.WriteLine($"Найден товар по ID {searchId}:");
                Console.WriteLine(foundProduct);
            }
            else
            {
                Console.WriteLine($"Товар с ID {searchId} не найден.");
            }

            searchId = 999;
            foundProduct = inventory.FindProductById(searchId);

            if (foundProduct is not null)
            {
                Console.WriteLine($"Найден товар по ID {searchId}:");
                Console.WriteLine(foundProduct);
            }
            else
            {
                Console.WriteLine($"Товар с ID {searchId} не найден.");
            }

            Console.WriteLine("\nДемонстрация удаления товара...");
            inventory.RemoveProduct(103);

            inventory.DisplayAllProducts();

            Console.WriteLine("Демонстрация возможностей record...");

            var updatedProduct = product2 with { Price = 16000.00m };
            Console.WriteLine($"Оригинал: {product2}");
            Console.WriteLine($"Обновленный: {updatedProduct}");
            Console.WriteLine($"Равны ли объекты? {product2 == updatedProduct}");

            Console.WriteLine("\nПолучение всех товаров через IReadOnlyList:");
            var allProducts = inventory.GetAllProducts();
            foreach (var product in allProducts)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\n=== РАБОТА ПРОГРАММЫ ЗАВЕРШЕНА ===");
        }
    }
}