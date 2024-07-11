using APIObesidad.Modelo;
using Microsoft.EntityFrameworkCore;

namespace APIObesidad.Contexts
{
    public class ConexionPostgreSQL: DbContext
    {

        public ConexionPostgreSQL(DbContextOptions<ConexionPostgreSQL> options) : base(options)
        {

        }

        public DbSet<turnos> Turnos => Set<turnos>();
        public DbSet<usuarios> Usuario => Set<usuarios>();
        public DbSet<medicos> Medico => Set<medicos>();
    }
}
