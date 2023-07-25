using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using School43_ASP.NET.Models;

namespace School43_ASP.NET.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Notify> Notifies { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DistResource> DistResource { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
