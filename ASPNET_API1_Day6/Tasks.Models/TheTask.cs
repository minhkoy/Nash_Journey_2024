namespace Tasks.Models
{
    public class TheTask
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public TheTask() { }
    }
}
