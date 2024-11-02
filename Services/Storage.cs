using System.Text.Json;
using TaskManager.Models;
using TaskManager.Helpers;

namespace TaskManager.Services {
    public static class Storage {
        private static readonly string FilePath = Config.DatabaseFilePath;

        public static List<Models.Task> LoadTasks() {
            if (!File.Exists(FilePath)) {
                return new List<Models.Task>();
            }

            var json = File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(json)) {
                return new List<Models.Task>();
            }

            try {
                return JsonSerializer.Deserialize<List<Models.Task>>(json) ?? new List<Models.Task>();
            } catch (JsonException) {
                return new List<Models.Task>();
            }
        }

        public static void SaveTasks(List<Models.Task> tasks) {
            var directory = Path.GetDirectoryName(FilePath);
            if (directory != null && !Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}