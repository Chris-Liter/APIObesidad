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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<usuarios>().ToTable("usuario");
        //    modelBuilder.Entity<turnos>().ToTable("turnos");

        //    modelBuilder.Entity<turnos>()
        //        .HasOne(t => t.id_usuario.ToString())
        //        .WithMany()
        //        .HasForeignKey(t => t.id_usuario)
        //        .OnDelete(DeleteBehavior.Cascade);
        //    modelBuilder.Entity<turnos>()
        //        .HasOne(t => t.id_medico.ToString())
        //        .WithMany()
        //        .HasForeignKey(t => t.id_medico)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
