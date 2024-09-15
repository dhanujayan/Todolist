using System.Runtime.CompilerServices;

namespace Todolist
{
    internal class Program
    {
        private static TaskManager taskManager = new TaskManager();
        static void Main(string[] args)
        {
           
            ShowMenu();
            while (true)
            {
                // get user input
                Console.WriteLine("Enter your choice(1-5): ");
                string? userInput = Console.ReadLine();

                // handle user request
                switch (userInput)
                {
                    case "1":
                        taskManager.AddTask();
                        break;
                    case "2":
                        taskManager.ViewTask();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                
            }

        }

        static void ShowMenu()
        {
            Console.WriteLine("\r\nWelcome to the To-Do List Application!\r\n\r\n1.Add a new task\r\n2.View all tasks\r\n3.Mark a task as completed\r\n4.Delete a task\r\n5.Exit\r\n");
        }
    }
}
