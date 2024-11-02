namespace TaskManager.Models {
    // Enumeration for task priority levels
    public enum PriorityEnum {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
        Blocker = 5
    }

    // Class representing a task priority
    public class Priority {
        public int Id { get; set; } = default(int); // Unique identifier for the priority
        public PriorityEnum Title { get; set; } = default(PriorityEnum); // Priority level
    }
}