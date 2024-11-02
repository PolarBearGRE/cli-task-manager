namespace TaskManager.Models {
    public enum StatusEnum {
        Completed = 1,
        Pending = 2,
        InProgress = 3,
        Cancelled = 4
    }

    public class Status {
        public int Id { get; set; } = default(int);
        public StatusEnum Title { get; set; } = default(StatusEnum);
    }
}