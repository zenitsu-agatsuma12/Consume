namespace Consume.Models
{
    public class Information
    {
        public int userId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Completed { get; set; }

        public Information() { }

        public Information (int userId, int id, string title, string completed)
        {
            this.userId = userId;
            Id = id;
            Title = title;
            Completed = completed;
        }
    }
}
