namespace TaskManager.Models {
    // Enumeration for task status
    public enum StatusEnum {
        Completed = 1,
        Pending = 2,
        InProgress = 3,
        Cancelled = 4
    }

    // Class representing a task status
    public class Status {
        public int Id { get; set; } = default(int); // Unique identifier for the status
        public StatusEnum Title { get; set; } = default(StatusEnum); // Status level
    }
}