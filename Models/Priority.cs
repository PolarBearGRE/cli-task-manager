namespace TaskManager.Models {
    public enum PriorityEnum {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
        Blocker = 5
    }
    public class Priority {
        public int Id { get; set; } = default(int);
        public PriorityEnum Title { get; set; } = default(PriorityEnum);
    }
}