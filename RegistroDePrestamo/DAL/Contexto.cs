using Microsoft.EntityFrameworkCore;
using RegistroDePrestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.DAL
{
  public  class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cuota> Cuota { get; set; }
        public DbSet<Roles> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source = DATA\Prestamo.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamos>().HasData(new Prestamos
            {
                Prestamoid = 1,
                Nombres = "Enel",
                Apellidos = "Almonte",
                NombreDeUsuario = "Profesor",
                Contrasena = "e1ab9d7f0b137ad16566742ad38863ec42b6d7fba157ef51638e60a4e044bd13"
                //Contrasena: cortina123
            });
        }
    }
}
