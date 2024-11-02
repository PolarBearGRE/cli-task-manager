using TaskManager.Models;

namespace TaskManager.Services {
    public class Add {
        public static void AddTask(string[] args) {
            Console.WriteLine("Arguments received:");
            foreach (var arg in args) {
                Console.WriteLine(arg);
            }

            var task = new Models.Task();
            var argumentHandlers = new Dictionary<string, Action<string>> {
                { "-t", value => task.Title = value },
                { "-d", value => task.Description = value },
                { "-s", value => task.Status = ParseInt(value, "Status") },
                { "-p", value => task.Priority = ParseInt(value, "Priority") }
            };

            for (int i = 0; i < args.Length; i++) {
                if (argumentHandlers.ContainsKey(args[i].ToLower())) {
                    var flag = args[i].ToLower();
                    var value = GetArgumentValue(args, ref i);
                    if (value == null) {
                        Console.WriteLine($"Error: '{flag}' flag requires a value.");
                        return;
                    }
                    argumentHandlers[flag](value);
                } else {
                    Console.WriteLine($"Unknown flag: {args[i]}");
                    return;
                }
            }

            if (task.Title == null) {
                Console.WriteLine("Error: Missing required field. Title is required.");
                return;
            }

            var tasks = Storage.LoadTasks();
            task.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1; // Generate unique ID
            tasks.Add(task);
            Storage.SaveTasks(tasks);

            Console.WriteLine($"Task added: Id={task.Id}, Title={task.Title}, Description={task.Description}, Status={task.Status}, Priority={task.Priority}");
        }

        private static string? GetArgumentValue(string[] args, ref int index) {
            if (index + 1 >= args.Length) {
                return null;
            }

            index++;
            string value = args[index];

            while (index + 1 < args.Length && !args[index + 1].StartsWith("-")) {
                index++;
                value += " " + args[index];
            }

            return value;
        }

        private static int ParseInt(string value, string fieldName) {
            if (int.TryParse(value, out int result)) {
                return result;
            } else {
                throw new ArgumentException($"Error: '{fieldName}' flag requires an integer value.");
            }
        }
    }
}