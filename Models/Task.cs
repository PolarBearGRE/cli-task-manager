namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; } = default(int); // Unique identifier for the task
        public string? Title { get; set; } = default(string); // Title of the task
        public string? Description { get; set; } = default(string); // Description of the task
        public int Status { get; set; } = 1; // Status of the task (default to 1)
        public int Priority { get; set; } = 1; // Priority of the task (default to 1)
        public DateTime? Created { get; set; } = null; // Timestamp when the task was created
        public DateTime? Updated { get; set; } = null; // Timestamp when the task was last updated
        public DateTime? Deleted { get; set; } = null; // Timestamp when the task was deleted
    }
}