using Microsoft.EntityFrameworkCore;
using MvcWebJobChollometro.Models;

namespace MvcWebJobChollometro.Data
{
    public class ChollometroContext : DbContext
    {

        public ChollometroContext(DbContextOptions<ChollometroContext> options) : base(options) { }

        public DbSet<Chollo> Chollos { get; set; }
    
    }
}
