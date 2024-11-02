using TaskManager.Models;

namespace TaskManager.Services
{
    public class Update
    {
        // Method to update a task based on the provided arguments
        public static void UpdateTask(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Invalid command. Usage: update <id> [-t \"title\"] [-d \"description\"] [-s status] [-pr priority]");
                return;
            }

            if (!int.TryParse(args[0], out int id))
            {
                Console.WriteLine("Invalid ID format. Usage: update <id> [-t \"title\"] [-d \"description\"] [-s status] [-pr priority]");
                return;
            }

            var tasks = Storage.LoadTasks(); // Load existing tasks

            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null || task.Deleted != null)
            {
                Console.WriteLine($"Task with ID {id} does not exist.");
                return;
            }

            var argumentHandlers = new Dictionary<string, Action<string>> {
                { "-t", value => task.Title = value }, // Update the task title
                { "-d", value => task.Description = value }, // Update the task description
                { "-s", value => task.Status = (int)ParseEnum<StatusEnum>(value, "Status") }, // Update the task status
                { "-pr", value => task.Priority = (int)ParseEnum<PriorityEnum>(value, "Priority") } // Update the task priority
            };

            for (int i = 1; i < args.Length; i++)
            {
                if (argumentHandlers.ContainsKey(args[i].ToLower()))
                {
                    var flag = args[i].ToLower();
                    var value = GetArgumentValue(args, ref i);
                    if (value == null)
                    {
                        Console.WriteLine($"Error: '{flag}' flag requires a value.");
                        return;
                    }
                    argumentHandlers[flag](value); // Handle the argument
                }
            }

            task.Updated = DateTime.UtcNow; // Update the timestamp

            Storage.SaveTasks(tasks); // Save the updated list of tasks

            Console.WriteLine($"Task with ID {id} has been updated.");
        }

        // Method to get the value of an argument
        private static string? GetArgumentValue(string[] args, ref int index)
        {
            if (index + 1 < args.Length)
            {
                var value = args[++index];
                while (index + 1 < args.Length && !args[index + 1].StartsWith("-"))
                {
                    value += " " + args[++index];
                }
                return value;
            }
            return null;
        }

        // Method to parse an enumeration value
        private static TEnum ParseEnum<TEnum>(string value, string fieldName) where TEnum : struct
        {
            if (Enum.TryParse(value, out TEnum result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Invalid value for {fieldName}: {value}");
            }
        }
    }
}