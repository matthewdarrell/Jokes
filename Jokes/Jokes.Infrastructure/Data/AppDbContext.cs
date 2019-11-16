using Jokes.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jokes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Joke> Jokes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => 
            options.UseSqlite("Data Source=jokes.db");
    }
}
