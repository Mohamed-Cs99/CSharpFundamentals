using System;

namespace TaskTracker
{
    class Program
    {
        public struct Tasks
        {
            public string title;
            public string desc;
            public bool completed;
        }

        static Tasks[] TasksArr = new Tasks[100];
        static int taskIndx = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your TaskTracker!");

            bool keepRunning = true;

            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Press 1 To Add New Task.");
                Console.WriteLine("Press 2 To Display All Tasks.");
                Console.WriteLine("Press 3 To Mark Task Completed.");
                Console.WriteLine("Press 4 To Remove Task.");
                Console.WriteLine("Press 5 To Exit.");
                Console.WriteLine("--------------------------");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        addNewTask();
                        break;
                    case "2":
                        viewAllTasks();
                        break;
                    case "3":
                        markAsCompleted();
                        break;
                    case "4":
                        removeTask();
                        break;
                    case "5":
                        Console.WriteLine("Bye Bye...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            } while (keepRunning);
        }

        public static void addNewTask()
        {
            if (taskIndx >= TasksArr.Length)
            {
                Console.WriteLine("Task list is full! Cannot add more tasks.");
                return;
            }

            Console.WriteLine("Enter task title:");
            string Task_title = Console.ReadLine();
            Console.WriteLine("Enter task description:");
            string description = Console.ReadLine();

            Tasks tsk = new Tasks
            {
                title = Task_title,
                desc = description,
                completed = false
            };

            TasksArr[taskIndx] = tsk;
            taskIndx++;
            Console.WriteLine();
            Console.WriteLine("Task Added Successfully!");
        }

        public static void viewAllTasks()
        {
            if (taskIndx <= 0)
            {
                Console.WriteLine("Tasks List is empty!");
            }
            else
            {
                for (int i = 0; i < taskIndx; i++)
                {
                    Console.WriteLine($"Task {i + 1}:");
                    Console.WriteLine($"  Title: {TasksArr[i].title}");
                    Console.WriteLine($"  Description: {TasksArr[i].desc}");
                    Console.WriteLine($"  Status: {(TasksArr[i].completed ? "Completed" : "Not Completed")}");
                }
            }
        }

        public static void removeTask()
        {
            Console.WriteLine("Enter task title you want to remove:");
            string t = Console.ReadLine();
            bool found = false;
            int indx = -1;

            for (int i = 0; i < taskIndx; i++)
            {
                if (t.Equals(TasksArr[i].title, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    indx = i;
                    break;
                }
            }

            if (found)
            {
                for (int i = indx; i < taskIndx - 1; i++)
                {
                    TasksArr[i] = TasksArr[i + 1];
                }
                taskIndx--;
                Console.WriteLine("Task Removed Successfully!");
                Console.WriteLine("--------------------------");
            }
            else
            {
                Console.WriteLine("Task not found!");
                Console.WriteLine("--------------------------");
            }
        }

        public static void markAsCompleted()
        {
            Console.WriteLine("Enter Completed Task id:");
            if (int.TryParse(Console.ReadLine(), out int tskId))
            {
                if (tskId > 0 && tskId <= taskIndx)
                {
                    TasksArr[tskId - 1].completed = true;
                    Console.WriteLine();
                    Console.WriteLine("Task marked as completed!");
                }
                else
                {
                    Console.WriteLine("Invalid Task ID!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
    }
}
