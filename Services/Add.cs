using TaskManager.Models;
using System;
using System.Collections.Generic;

namespace TaskManager.Services {
    // Service class for adding tasks
    public class Add {
        // Method to add a task based on command-line arguments
        public static void AddTask(string[] args) {
            Console.WriteLine("Arguments received:");
            foreach (var arg in args) {
                Console.WriteLine(arg); // Print each argument
            }

            var task = new Models.Task {
                Created = DateTime.UtcNow // Set the creation timestamp
            };

            // Dictionary to handle command-line arguments
            var argumentHandlers = new Dictionary<string, Action<string>> {
                { "-t", value => task.Title = value }, // Set the task title
                { "-d", value => task.Description = value }, // Set the task description
                { "-s", value => task.Status = (int)ParseEnum<StatusEnum>(value, "Status") }, // Set the task status
                { "-p", value => task.Priority = (int)ParseEnum<PriorityEnum>(value, "Priority") } // Set the task priority
            };

            // Process each argument
            for (int i = 0; i < args.Length; i++) {
                if (argumentHandlers.ContainsKey(args[i].ToLower())) {
                    var flag = args[i].ToLower();
                    var value = GetArgumentValue(args, ref i);
                    if (value == null) {
                        Console.WriteLine($"Error: '{flag}' flag requires a value.");
                        return;
                    }
                    argumentHandlers[flag](value); // Handle the argument
                }
            }

            var tasks = Storage.LoadTasks(); // Load existing tasks
            task.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1; // Generate a unique ID for the new task
            tasks.Add(task); // Add the new task
            Storage.SaveTasks(tasks); // Save the updated list of tasks

            // Print the details of the added task
            Console.WriteLine("Task added successfully:");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Status: {task.Status}");
            Console.WriteLine($"Priority: {task.Priority}");
            Console.WriteLine($"Created: {task.Created}");
        }

        // Method to get the value of an argument
        private static string? GetArgumentValue(string[] args, ref int index) {
            if (index + 1 < args.Length) {
                var value = args[++index];
                while (index + 1 < args.Length && !args[index + 1].StartsWith("-")) {
                    value += " " + args[++index];
                }
                return value;
            }
            return null;
        }

        // Method to parse an integer value
        private static int ParseInt(string value, string fieldName) {
            if (int.TryParse(value, out int result)) {
                return result;
            } else {
                throw new ArgumentException($"Invalid value for {fieldName}: {value}");
            }
        }

        // Method to parse an enumeration value
        private static TEnum ParseEnum<TEnum>(string value, string fieldName) where TEnum : struct {
            if (Enum.TryParse(value, out TEnum result)) {
                return result;
            } else {
                throw new ArgumentException($"Invalid value for {fieldName}: {value}");
            }
        }
    }
}