using TaskManager.Services;

namespace TaskManager {
    // Main class for the Task Manager application
    public class TaskManager {
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("No command provided. Please use one of the following commands: add, list, update, delete.");
                return;
            }

            // Handle different commands
            switch (args[0].ToLower()) {
                case "add":
                    Add.AddTask(args.Skip(1).ToArray()); // Call the AddTask method
                    break;
                case "list":
                    Console.WriteLine("list"); // Placeholder for list command
                    break;
                case "update":
                    Console.WriteLine("update"); // Placeholder for update command
                    break;
                case "delete":
                    Console.WriteLine("delete"); // Placeholder for delete command
                    break;
                default:
                    Console.WriteLine("Wrong command! Please use one of the following commands: add, list, update, delete.");
                    break;
            }
        }
    }
}