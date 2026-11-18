using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> tasks = new List<string>();
        bool running = true;

        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddTask(tasks);
                    break;
                case "2":
                    RemoveTask(tasks);
                    break;
                case "3":
                    ShowTasks(tasks);
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Choose 1, 2, 3, or 4.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("TO-DO LIST");
        Console.WriteLine("1. Add a task");
        Console.WriteLine("2. Remove a task");
        Console.WriteLine("3. Show tasks");
        Console.WriteLine("4. Quit");
        Console.Write("Choose an option: ");
    }

    private static void AddTask(List<string> tasks)
    {
        Console.Write("Enter a task: ");
        string task = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Task cannot be empty.");
            return;
        }

        tasks.Add(task.Trim());
        Console.WriteLine("Task added.");
    }

    private static void RemoveTask(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("There are no tasks to remove.");
            return;
        }

        ShowTasks(tasks);
        Console.Write("Enter the task number to remove: ");
        string text = Console.ReadLine() ?? "";

        if (!int.TryParse(text, out int number) || number < 1 || number > tasks.Count)
        {
            Console.WriteLine("Enter a valid task number.");
            return;
        }

        tasks.RemoveAt(number - 1);
        Console.WriteLine("Task removed.");
    }

    private static void ShowTasks(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Your list is empty.");
            return;
        }

        Console.WriteLine("Your tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }
}