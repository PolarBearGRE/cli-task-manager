namespace TaskManager.Services
{
    public class Delete
    {
        // Method to delete a task based on the provided ID
        public static void DeleteTask(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid command. Usage: delete <id>");
                return;
            }

            if (!int.TryParse(args[0], out int id))
            {
                Console.WriteLine("Invalid ID format. Usage: delete <id>");
                return;
            }

            var tasks = Storage.LoadTasks(); // Load existing tasks

            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }

            task.Deleted = DateTime.UtcNow; // Mark the task as deleted

            Storage.SaveTasks(tasks); // Save the updated list of tasks

            Console.WriteLine($"Task with ID {id} has been deleted.");
        }
    }
}