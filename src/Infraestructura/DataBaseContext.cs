using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infraestructura
{
    public class DataBaseContext : DbContext
    {
        private readonly ILogger<DataBaseContext> _logger;
        public DataBaseContext(DbContextOptions<DataBaseContext> options, ILogger<DataBaseContext> logger) :base(options)
        {
            _logger = logger;
            LogConnectionString();
        }
        private void LogConnectionString()
        {
            var connectionString = Database.GetConnectionString();
            _logger.LogInformation("Cadena de conexión utilizada: {ConnectionString}", connectionString);
        }
        public DbSet<Unidad> Unidad { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Cama> Cama { get; set; }
        public DbSet<Comuna> Comuna { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ingreso> Ingreso { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unidad>(o =>
            {
                o.HasKey(x => x.IdUnidad);
                o.Property(x => x.IdUnidad);
                o.Property(x => x.Nombre);
            });
            modelBuilder.Entity<Sala>(o =>
            {
                o.HasKey(x => x.IdSala);
                o.Property(x => x.IdSala);
                o.Property(x => x.Numero);
                o.Property(x => x.IdUnidad);
            });
            modelBuilder.Entity<Cama>(o =>
            {
                o.HasKey(x => x.IdCama);
                o.Property(x => x.IdCama);
                o.Property(x => x.Numero);
                o.Property(x => x.Sexo);
                o.HasOne(x => x.Sala)
                                .WithMany()
                                .HasForeignKey(x => x.IdSala);
                o.Property(x => x.IdEstadoCama);
            });
            modelBuilder.Entity<Comuna>(o =>
            {
                o.HasKey(x => x.IdComuna);
                o.Property(x => x.IdComuna);
                o.Property(x => x.Nombre);
            });
            modelBuilder.Entity<UsuarioRol>(o =>
            {
                o.HasKey(x => x.IdRol);
                o.Property(x => x.IdRol);
                o.Property(x => x.Nombre);
            });
            modelBuilder.Entity<Paciente>(o =>
            {
                o.HasKey(x => x.IdPaciente);
                o.Property(x => x.IdPaciente);
                o.Property(x => x.Nombre);
                o.Property(x => x.ApellidoPaterno);
                o.Property(x => x.ApellidoPaterno);
                o.Property(x => x.Sexo);
                o.Property(x => x.Direccion);
                o.Property(x => x.Alergias);
                o.Property(x => x.Celular);
                o.Property(x => x.FechaCreacion);
                o.Property(x => x.FechaModificacion);
                o.Property(x => x.FechaNacimiento);
                o.Property(x => x.IdComuna);
                o.OwnsOne(e => e.Rut, conf =>
                {
                    conf.Property(x => x.Documento).HasColumnName("Rut");
                });
                o.OwnsOne(e => e.Rut, conf =>
                {
                    conf.Property(x => x.Digito).HasColumnName("Dv");
                });
            });
            modelBuilder.Entity<Usuario>(o =>
            {
                o.HasKey(x => x.IdUsuario);
                o.Property(x => x.IdUsuario);
                o.Property(x => x.Nombre);
                o.OwnsOne(e => e.Rut, conf =>
                {
                    conf.Property(x => x.Documento).HasColumnName("Rut");
                });
                o.OwnsOne(e => e.Rut, conf =>
                {
                    conf.Property(x => x.Digito).HasColumnName("Dv");
                });
                o.Property(x => x.Contrasena);
                o.OwnsOne(e => e.Email, conf =>
                {
                    conf.Property(x => x.Email).HasColumnName("Email");
                });
                o.Property(x => x.FechaCreacion);
                o.Property(x => x.FechaModificacion);
                o.HasOne(i => i.Rol)
                              .WithMany()
                              .HasForeignKey(i => i.IdRol);

            });
            modelBuilder.Entity<Ingreso>(o =>
            {
                o.HasKey(x => x.IdIngreso);
                o.Property(x => x.IdIngreso);
                o.Property(x => x.Sintomas);
                o.Property(x => x.Diagnostico);
                o.HasOne(i => i.Paciente)
                              .WithMany()
                              .HasForeignKey(i => i.IdPaciente);
                o.Property(x => x.IdEstado);
                o.Property(x => x.IdUnidad);
                o.HasOne(i => i.Unidad)
                              .WithMany()
                              .HasForeignKey(i => i.IdUnidad);
                o.Property(x => x.IdCama);
                o.Property(x => x.FechaAlta);
                o.Property(x => x.FechaCreacion);
                o.Property(x => x.FechaModificacion);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}