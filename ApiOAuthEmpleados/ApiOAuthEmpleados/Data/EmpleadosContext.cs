using ApiOAuthEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiOAuthEmpleados.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
