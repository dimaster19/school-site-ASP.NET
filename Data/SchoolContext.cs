using Microsoft.EntityFrameworkCore;
using School43_ASP.NET.Models;

namespace School43_ASP.NET.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Rank> Ranks { get; set; }
    }
}
