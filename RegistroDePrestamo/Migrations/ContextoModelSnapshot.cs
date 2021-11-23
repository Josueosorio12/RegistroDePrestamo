﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroDePrestamo.DAL;

namespace RegistroDePrestamo.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("RegistroDePrestamo.Entidades.Clientes", b =>
                {
                    b.Property<int>("CodigoCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApellidoReferencia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ciudad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaCliente")
                        .HasColumnType("TEXT");

                    b.Property<string>("LugarTrabajo")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreReferencia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ocupacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Parentesco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .HasColumnType("TEXT");

                    b.Property<int>("SueldoMensual")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoReferencia")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("TEXT");

                    b.HasKey("CodigoCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroDePrestamo.Entidades.Empleados", b =>
                {
                    b.Property<int>("CodigoEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ciudad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Empresa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaEmpleado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPago")
                        .HasColumnType("TEXT");

                    b.HasKey("CodigoEmpleado");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("RegistroDePrestamo.Entidades.PrestamoDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientesCodigoCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmpleadosCodigoEmpleado")
                        .HasColumnType("INTEGER");

                    b.Property<float>("MontoCuota")
                        .HasColumnType("REAL");

                    b.Property<float>("MontoTotal")
                        .HasColumnType("REAL");

                    b.Property<int>("NumeroCuota")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Prestamoid")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalIntereses")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ClientesCodigoCliente");

                    b.HasIndex("EmpleadosCodigoEmpleado");

                    b.HasIndex("Prestamoid");

                    b.ToTable("PrestamoDetalle");
                });

            modelBuilder.Entity("RegistroDePrestamo.Entidades.Prestamos", b =>
                {
                    b.Property<int>("Prestamoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ciudad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasena")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaPago")
                        .HasColumnType("TEXT");

                    b.Property<float>("Interes")
                        .HasColumnType("REAL");

                    b.Property<string>("LugarTrabajo")
                        .HasColumnType("TEXT");

                    b.Property<float>("MontoCuota")
                        .HasColumnType("REAL");

                    b.Property<float>("MontoPrestamo")
                        .HasColumnType("REAL");

                    b.Property<float>("MontoTotal")
                        .HasColumnType("REAL");

                    b.Property<string>("NombreDeUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroCuota")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ocupacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .HasColumnType("TEXT");

                    b.Property<int>("SueldoMensual")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("TEXT");

                    b.Property<float>("TotalIntereses")
                        .HasColumnType("REAL");

                    b.HasKey("Prestamoid");

                    b.ToTable("Prestamos");

                    b.HasData(
                        new
                        {
                            Prestamoid = 1,
                            Apellidos = "Almonte",
                            Contrasena = "e1ab9d7f0b137ad16566742ad38863ec42b6d7fba157ef51638e60a4e044bd13",
                            FechaRegistro = new DateTime(2021, 11, 23, 16, 22, 20, 733, DateTimeKind.Local).AddTicks(8085),
                            Interes = 0f,
                            MontoCuota = 0f,
                            MontoPrestamo = 0f,
                            MontoTotal = 0f,
                            NombreDeUsuario = "Profesor",
                            Nombres = "Enel",
                            NumeroCuota = 0,
                            SueldoMensual = 0,
                            TotalIntereses = 0f
                        });
                });

            modelBuilder.Entity("RegistroDePrestamo.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Activo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("RolID")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("RegistroDePrestamo.Entidades.PrestamoDetalle", b =>
                {
                    b.HasOne("RegistroDePrestamo.Entidades.Clientes", null)
                        .WithMany("Detalles")
                        .HasForeignKey("ClientesCodigoCliente");

                    b.HasOne("RegistroDePrestamo.Entidades.Empleados", null)
                        .WithMany("Detalles")
                        .HasForeignKey("EmpleadosCodigoEmpleado");

                    b.HasOne("RegistroDePrestamo.Entidades.Prestamos", "Prestamos")
                        .WithMany("Detalle")
                        .HasForeignKey("Prestamoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("RegistroDePrestamo.Entidades.Clientes", b =>
                {
                    b.Navigation("Detalles");
                });

            modelBuilder.Entity("RegistroDePrestamo.Entidades.Empleados", b =>
                {
                    b.Navigation("Detalles");
                });

            modelBuilder.Entity("RegistroDePrestamo.Entidades.Prestamos", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
