using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroDePrestamo.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCliente = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", nullable: true),
                    EstadoCivil = table.Column<string>(type: "TEXT", nullable: true),
                    Ocupacion = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    LugarTrabajo = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    SueldoMensual = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreReferencia = table.Column<string>(type: "TEXT", nullable: true),
                    ApellidoReferencia = table.Column<string>(type: "TEXT", nullable: true),
                    TelefonoReferencia = table.Column<string>(type: "TEXT", nullable: true),
                    Parentesco = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    CodigoEmpleado = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaEmpleado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: true),
                    EstadoCivil = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Empresa = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPago = table.Column<string>(type: "TEXT", nullable: true),
                    Ingreso = table.Column<string>(type: "TEXT", nullable: true),
                    Cargo = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.CodigoEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Prestamoid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EstadoCivil = table.Column<string>(type: "TEXT", nullable: true),
                    FormaPago = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    LugarTrabajo = table.Column<string>(type: "TEXT", nullable: true),
                    Ocupacion = table.Column<string>(type: "TEXT", nullable: true),
                    SueldoMensual = table.Column<int>(type: "INTEGER", nullable: false),
                    MontoPrestamo = table.Column<float>(type: "REAL", nullable: false),
                    Interes = table.Column<float>(type: "REAL", nullable: false),
                    NumeroCuota = table.Column<int>(type: "INTEGER", nullable: false),
                    MontoCuota = table.Column<float>(type: "REAL", nullable: false),
                    TotalIntereses = table.Column<float>(type: "REAL", nullable: false),
                    MontoTotal = table.Column<float>(type: "REAL", nullable: false),
                    Contrasena = table.Column<string>(type: "TEXT", nullable: true),
                    NombreDeUsuario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Prestamoid);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaIngreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Alias = table.Column<string>(type: "TEXT", nullable: true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Clave = table.Column<string>(type: "TEXT", nullable: true),
                    RolID = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "PrestamoDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Prestamoid = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroCuota = table.Column<int>(type: "INTEGER", nullable: false),
                    MontoCuota = table.Column<float>(type: "REAL", nullable: false),
                    TotalIntereses = table.Column<float>(type: "REAL", nullable: false),
                    MontoTotal = table.Column<float>(type: "REAL", nullable: false),
                    EmpleadosCodigoEmpleado = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrestamoDetalle_Empleados_EmpleadosCodigoEmpleado",
                        column: x => x.EmpleadosCodigoEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "CodigoEmpleado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrestamoDetalle_Prestamos_Prestamoid",
                        column: x => x.Prestamoid,
                        principalTable: "Prestamos",
                        principalColumn: "Prestamoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "Prestamoid", "Apellidos", "Celular", "Ciudad", "Contrasena", "Direccion", "Email", "EstadoCivil", "FechaRegistro", "FormaPago", "Interes", "LugarTrabajo", "MontoCuota", "MontoPrestamo", "MontoTotal", "NombreDeUsuario", "Nombres", "NumeroCuota", "NumeroDocumento", "Ocupacion", "Sexo", "SueldoMensual", "Telefono", "TipoDocumento", "TotalIntereses" },
                values: new object[] { 1, "Almonte", null, null, "e1ab9d7f0b137ad16566742ad38863ec42b6d7fba157ef51638e60a4e044bd13", null, null, null, new DateTime(2021, 11, 22, 22, 23, 48, 835, DateTimeKind.Local).AddTicks(803), null, 0f, null, 0f, 0f, 0f, "Profesor", "Enel", 0, null, null, null, 0, null, null, 0f });

            migrationBuilder.CreateIndex(
                name: "IX_PrestamoDetalle_EmpleadosCodigoEmpleado",
                table: "PrestamoDetalle",
                column: "EmpleadosCodigoEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamoDetalle_Prestamoid",
                table: "PrestamoDetalle",
                column: "Prestamoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PrestamoDetalle");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
