namespace Core.Entities
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public List<ToDo>? ToDos { get; set; }
    }
}
