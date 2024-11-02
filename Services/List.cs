using TaskManager.Models;

namespace TaskManager.Services {
    public class List {
        // Method to list tasks based on command-line arguments
        public static void ListTasks(string[] args) {
            // Print the received arguments for debugging
            Console.WriteLine("Arguments received:");
            foreach (var arg in args) {
                Console.WriteLine(arg);
            }

            var tasks = Storage.LoadTasks(); // Load existing tasks

            // Check if at least one argument is provided
            if (args.Length < 1) {
                Console.WriteLine("Invalid command. Usage: list <id|all|-param \"parameter=value\">");
                return;
            }

            var secondArg = args[0].ToLower(); // Get the first argument and convert to lowercase

            // Handle the 'all' command to list all tasks
            if (secondArg == "all") {
                if (args.Length > 1) {
                    Console.WriteLine("Invalid command. Usage: list all");
                    return;
                }
                PrintTasks(tasks); // Print all tasks
                return;
            }
            // Handle the command to list a specific task by ID
            else if (int.TryParse(secondArg, out int id)) {
                if (args.Length > 1) {
                    Console.WriteLine("Invalid command. Usage: list <id>");
                    return;
                }
                var task = tasks.FirstOrDefault(t => t.Id == id);
                if (task != null) {
                    PrintTask(task); // Print the specific task
                } else {
                    Console.WriteLine($"Task with ID {id} not found.");
                }
                return;
            }
            // Handle the command to filter tasks by a parameter
            else if (secondArg == "-param") {
                if (args.Length < 2) {
                    Console.WriteLine("Error: '-param' flag requires a parameter.");
                    return;
                }
                var parameter = args[1];
                FilterTasksByParameter(tasks, parameter); // Filter tasks by the provided parameter
                return;
            } else {
                Console.WriteLine("Invalid command. Usage: list <id|all|-param \"parameter=value\">");
                return;
            }
        }

        // Method to filter tasks by a single parameter
        private static void FilterTasksByParameter(List<Models.Task> tasks, string parameter) {
            var keyValuePairs = parameter.Split(',');

            foreach (var keyValue in keyValuePairs) {
                var keyValueArray = keyValue.Split('=');
                if (keyValueArray.Length != 2) {
                    Console.WriteLine($"Invalid parameter format: {keyValue}. Expected format: parameter=value");
                    return;
                }

                var key = keyValueArray[0].ToLower();
                var value = keyValueArray[1];

                switch (key) {
                    case "status":
                        if (Enum.TryParse<StatusEnum>(value, out var status)) {
                            tasks = tasks.Where(t => t.Status == (int)status).ToList();
                        } else {
                            Console.WriteLine($"Invalid status value: {value}");
                            return;
                        }
                        break;
                    case "priority":
                        if (Enum.TryParse<PriorityEnum>(value, out var priority)) {
                            tasks = tasks.Where(t => t.Priority == (int)priority).ToList();
                        } else {
                            Console.WriteLine($"Invalid priority value: {value}");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine($"Unknown parameter: {key}. Only 'status' and 'priority' are allowed.");
                        return;
                }
            }

            PrintTasks(tasks);
        }

        // Method to get the value of an argument
        private static string? GetArgumentValue(string[] args, ref int index) {
            if (index + 1 < args.Length) {
                return args[++index];
            }
            return null;
        }

        // Method to print a single task
        private static void PrintTask(Models.Task task) {
            if (task.Deleted == null) {
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Status: {Enum.GetName(typeof(StatusEnum), task.Status)}");
                Console.WriteLine($"Priority: {Enum.GetName(typeof(PriorityEnum), task.Priority)}");
            }
            Console.WriteLine();
        }

        // Method to print a list of tasks
        private static void PrintTasks(List<Models.Task> tasks) {
            if (tasks.Count == 0) {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in tasks) {
                PrintTask(task);
            }
        }
    }
}