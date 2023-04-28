using ApiCoreCrudDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDoctores.Data
{
    public class ContextDoctores : DbContext
    {
        public ContextDoctores(DbContextOptions<ContextDoctores> options) : base(options) { }

        public DbSet<Doctor> Doctores { get; set; }

    }
}
