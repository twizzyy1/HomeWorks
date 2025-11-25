using System;
using System.Collections.Generic;

namespace TaskManager
{
    public class TaskItem
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public TaskItem(string description)
        {
            Description = description;
            IsDone = false;
        }

        public override string ToString()
        {
            string status = IsDone ? "[X]" : "[ ]";
            return $"{status} {Description}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== список задач ===\n");

            List<TaskItem> tasks = new List<TaskItem>();

            bool isRunning = true;

            while (isRunning)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(tasks);
                        break;
                    case "2":
                        ShowTasks(tasks);
                        break;
                    case "3":
                        MarkTaskAsDone(tasks);
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Программа завершена. До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("меню:");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Посмотреть задачи");
            Console.WriteLine("3. Отметить задачу как выполненную");
            Console.WriteLine("4. Выйти");
            Console.Write("Выберите действие: ");
        }

        static void AddTask(List<TaskItem> tasks)
        {
            Console.Write("Введите описание новой задачи: ");
            string description = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(description))
            {
                TaskItem newTask = new TaskItem(description);
                tasks.Add(newTask);
                Console.WriteLine($"Задача добавлена: {description}\n");
            }
            else
            {
                Console.WriteLine("Описание задачи не может быть пустым!\n");
            }
        }

        static void ShowTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("\n--- список задач ---");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Задачи отсутствуют.\n");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
            Console.WriteLine();
        }

        static void MarkTaskAsDone(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст. Нечего отмечать как выполненное.\n");
                return;
            }

            ShowTasks(tasks);
            Console.Write("Введите номер задачи для отметки как выполненной: ");

            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                if (taskNumber >= 1 && taskNumber <= tasks.Count)
                {
                    TaskItem task = tasks[taskNumber - 1];
                    if (!task.IsDone)
                    {
                        task.IsDone = true;
                        Console.WriteLine($"Задача отмечена как выполненная: {task.Description}\n");
                    }
                    else
                    {
                        Console.WriteLine("Эта задача уже была выполнена!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный номер задачи!\n");
                }
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите корректный номер!\n");
            }
        }
    }
}
