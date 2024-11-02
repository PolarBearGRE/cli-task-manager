
namespace TaskManager.Models
{
    public class Task {
        public int Id { get; set; } = default(int);
        public string? Title { get; set; } = default(string);
        public string? Description { get; set; } = default(string);
        public int Status { get; set; } = 1;
        public int Priority { get; set; } = 1;

    }
}