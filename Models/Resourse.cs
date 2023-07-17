namespace School43_ASP.NET.Models
{
    public class Resourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int WorkerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Worker Worker { get; set; }

    }
}
