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
        public DbSet<Moras> Moras { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source = DATA\Prestamo.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamos>().HasData(new Prestamos
            {
                Prestamoid = 1,
                Nombres = "Josue",
                Apellidos = "Osorio",
                NombreDeUsuario = "JosueO",
                Contrasena = "952152105eb089236d0a4e37344a7a65323ce4f1d4016a6fbad3433b5122ff9b"
                //Contrasena: Josue123
            });

            modelBuilder.Entity<Prestamos>().HasData(new Prestamos
            {
                Prestamoid = 2,
                Nombres = "Reny",
                Apellidos = "Diaz",
                NombreDeUsuario = "Rdiaz",
                Contrasena = "72bfda8ad26e77fa13f7fbcbd15ca12877f62354c6e57ba27ce2bfcaa1a359f1"
                //Contrasena: Reny123
            });


        }
    }
}
