using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    public class TaskManager
    {
        // Lists to store description and completion
        private List<string> tasks = new List<string>();
        private List<bool> taskCompletion = new List<bool>();
        
        //method to add new task
        public void AddTask()
        {
            Console.WriteLine("Enter the Task Description");
            string? taskDescription = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(taskDescription))
            {
                tasks.Add(taskDescription);
                taskCompletion.Add(false);
                Console.WriteLine("Task Successfully added");
            }
            else
            {
                Console.WriteLine("task description cannot be empty");
            }
                     
        }

        public void ViewTask()
        {
            if (!tasks.Any())
            {
                Console.WriteLine("No tasks available for display");
                return;
            }

            Console.WriteLine("1.View all Tasks\n2.Search for a task");
            String? choice = Console.ReadLine();

            if (choice == "1")
            {
                DisplayAllTasks();
            }

            else if (choice == "2")
            {
                SearchTaskByName();
            }

            else
            {
                Console.WriteLine("Invalid choice.Returning to main menu");
            }
        }

        private void DisplayAllTasks()
        {
            Console.WriteLine("Here are all your tasks");

            tasks.Select((task, index) => new { task, index }).ToList().ForEach(item =>
            {
                string status = taskCompletion[item.index] ? "[Completed]" : "[Pending]";
                Console.WriteLine($"{item.index + 1}. {item.task} {status}");
            });

        }

        private void SearchTaskByName()
        {
            Console.WriteLine("Enter the task name");
            string? searchTerm = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var foundTasks = tasks.Select((task, index) => new { Task = task, Index = index }).
                    Where(item => item.Task.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                if (foundTasks.Any())
                {
                    foundTasks.ForEach(item =>
                    {
                        string status = taskCompletion[item.Index] ? "[Completed]" : "[Pending]";
                        Console.WriteLine($"{item.Index + 1}. {item.Task} {status}");
                    });
                }
                else
                {
                    Console.WriteLine("No task found with that name");
                }
            }
            else
            {
                Console.WriteLine("Please enter the task name");
            }
        }

        public bool MarkTaskCompleted()
        {
            DisplayAllTasks();
            Console.WriteLine("Enter the number of the task to mark as completed");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
            {
                int index = taskNumber - 1;
                if (!taskCompletion[index])
                {
                    taskCompletion[index] = true;
                    Console.WriteLine($"Task '{tasks[index]}' marked as Completed");
                    return true;
                }
                else
                {
                    Console.WriteLine("Task is already marked as completed");
                    return false;
                }
            }
            else 
            {
                Console.WriteLine("Invalid task number");
                return false;
            }

        }


    }
}
