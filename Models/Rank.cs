namespace School43_ASP.NET.Models
{
    public class Rank
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }
}
