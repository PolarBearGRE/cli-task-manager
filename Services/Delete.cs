namespace TaskManager.Services
{
    public class Delete
    {
        // Method to delete a task based on the provided ID
        public static void DeleteTask(string[] args)
        {
            // Check if exactly one argument (task ID) is provided
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid command. Usage: delete <id>");
                return;
            }

            // Validate that the provided argument is a valid integer (task ID)
            if (!int.TryParse(args[0], out int id))
            {
                Console.WriteLine("Invalid ID format. Usage: delete <id>");
                return;
            }

            // Load existing tasks from storage
            var tasks = Storage.LoadTasks();

            // Find the task with the specified ID
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }

            // Mark the task as deleted by setting the Deleted timestamp
            task.Deleted = DateTime.UtcNow;

            // Save the updated list of tasks to storage
            Storage.SaveTasks(tasks);

            Console.WriteLine($"Task with ID {id} has been deleted.");
        }
    }
}