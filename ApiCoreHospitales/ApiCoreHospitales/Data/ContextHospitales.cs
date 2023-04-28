using ApiCoreHospitales.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreHospitales.Data
{
    public class ContextHospitales : DbContext
    {
        public ContextHospitales(DbContextOptions<ContextHospitales> options) : base(options) { }

        public DbSet<Hospital> Hospitales { get; set; }
    }
}
