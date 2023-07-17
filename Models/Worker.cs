namespace School43_ASP.NET.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RankId { get; set; }
        public string Photo { get; set; }
        public string FullRank { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Rank Rank { get; set; }
        public List<Resourse> Resourses { get; set; }

    }
}
