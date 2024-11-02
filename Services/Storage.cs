using System.Text.Json;
using TaskManager.Models;
using TaskManager.Helpers;

namespace TaskManager.Services {
    // Service class for handling storage operations
    public static class Storage {
        private static readonly string FilePath = Config.DatabaseFilePath; // Path to the database file

        // Method to load tasks from the JSON file
        public static List<Models.Task> LoadTasks() {
            if (!File.Exists(FilePath)) {
                return new List<Models.Task>(); // Return an empty list if the file does not exist
            }

            var json = File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(json)) {
                return new List<Models.Task>(); // Return an empty list if the file is empty
            }

            try {
                return JsonSerializer.Deserialize<List<Models.Task>>(json) ?? new List<Models.Task>(); // Deserialize the JSON content
            } catch (JsonException) {
                return new List<Models.Task>(); // Return an empty list if deserialization fails
            }
        }

        // Method to save tasks to the JSON file
        public static void SaveTasks(List<Models.Task> tasks) {
            var directory = Path.GetDirectoryName(FilePath);
            if (directory != null && !Directory.Exists(directory)) {
                Directory.CreateDirectory(directory); // Create the directory if it does not exist
            }

            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true }); // Serialize the tasks to JSON
            File.WriteAllText(FilePath, json); // Write the JSON content to the file
        }
    }
}