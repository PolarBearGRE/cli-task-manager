using TaskManager.Services;

namespace TaskManager {
    public class TaskManager {
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("No command provided. Please use one of the following commands: add, list, update, delete.");
                return;
            }

            switch (args[0].ToLower()) {
                case "add":
                    Add.AddTask(args.Skip(1).ToArray());
                    break;
                case "list":
                    Console.WriteLine("list");
                    break;
                case "update":
                    Console.WriteLine("update");
                    break;
                case "delete":
                    Console.WriteLine("delete");
                    break;
                default:
                    Console.WriteLine("Wrong command! Please use one of the following commands: add, list, update, delete.");
                    break;
            }
        }
    }
}