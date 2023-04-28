using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobChollometro.Models;

namespace WebJobChollometro.Data
{
    public class ChollometroContext :DbContext
    {
        public ChollometroContext(DbContextOptions<ChollometroContext> options):base(options) { }

        public DbSet<Chollo> Chollos { get; set; }

    }
}
