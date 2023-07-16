namespace Core.Entities
{
    public class ToDo
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string DueDate { get; set; }
        public decimal EstimatedTime { get; set; }
        public string TimeFrame { get; set; }
        public string Importance { get; set; }
        public string Category { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

    }

    public class ToDoDto
    {
        public int TodoId { get; set; }
        public string? Title { get; set; }
        public DateTime DueDate { get; set; }
        public decimal EstimatedTime { get; set; }
        public string TimeFrame { get; set; }
        public string? Importance { get; set; }
        public string Category { get; set; }
        public int StatusId { get; set; }
    }
}
