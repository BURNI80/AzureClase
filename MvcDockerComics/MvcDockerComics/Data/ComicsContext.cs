using Microsoft.EntityFrameworkCore;
using MvcDockerComics.Models;

namespace MvcDockerComics.Data
{
    public class ComicsContext : DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options)
            : base(options) { }
        public DbSet<Comic> Comics { get; set; }
    }
}
