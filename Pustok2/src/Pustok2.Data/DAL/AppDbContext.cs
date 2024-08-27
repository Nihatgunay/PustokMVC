using Microsoft.EntityFrameworkCore;
using Pustok2.Core.Models;

namespace Pustok2.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Slide> Slides { get; set; }
    }
}
