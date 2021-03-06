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
                name: "Moras",
                columns: table => new
                {
                    MoraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moras", x => x.MoraId);
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
                    NombreDeUsuario = table.Column<string>(type: "TEXT", nullable: true),
                    Mora = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Prestamoid);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
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
                name: "MorasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoraId = table.Column<int>(type: "INTEGER", nullable: false),
                    Prestamoid = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MorasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MorasDetalle_Moras_MoraId",
                        column: x => x.MoraId,
                        principalTable: "Moras",
                        principalColumn: "MoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    IdCuota = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Prestamoid = table.Column<int>(type: "INTEGER", nullable: true),
                    NumeroCuota = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaPagoCuota = table.Column<string>(type: "TEXT", nullable: true),
                    Interes = table.Column<float>(type: "REAL", nullable: false),
                    Capital = table.Column<float>(type: "REAL", nullable: false),
                    Total = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.IdCuota);
                    table.ForeignKey(
                        name: "FK_Cuota_Prestamos_Prestamoid",
                        column: x => x.Prestamoid,
                        principalTable: "Prestamos",
                        principalColumn: "Prestamoid",
                        onDelete: ReferentialAction.Restrict);
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
                    ClientesCodigoCliente = table.Column<int>(type: "INTEGER", nullable: true),
                    EmpleadosCodigoEmpleado = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrestamoDetalle_Clientes_ClientesCodigoCliente",
                        column: x => x.ClientesCodigoCliente,
                        principalTable: "Clientes",
                        principalColumn: "CodigoCliente",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "Prestamoid", "Apellidos", "Celular", "Ciudad", "Contrasena", "Direccion", "Email", "EstadoCivil", "FechaRegistro", "FormaPago", "Interes", "LugarTrabajo", "MontoCuota", "MontoPrestamo", "MontoTotal", "Mora", "NombreDeUsuario", "Nombres", "NumeroCuota", "NumeroDocumento", "Ocupacion", "Sexo", "SueldoMensual", "Telefono", "TipoDocumento", "TotalIntereses" },
                values: new object[] { 1, "Osorio", null, null, "952152105eb089236d0a4e37344a7a65323ce4f1d4016a6fbad3433b5122ff9b", null, null, null, new DateTime(2021, 12, 6, 20, 57, 30, 149, DateTimeKind.Local).AddTicks(7965), null, 0f, null, 0f, 0f, 0f, 0, "JosueO", "Josue", 0, null, null, null, 0, null, null, 0f });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "Prestamoid", "Apellidos", "Celular", "Ciudad", "Contrasena", "Direccion", "Email", "EstadoCivil", "FechaRegistro", "FormaPago", "Interes", "LugarTrabajo", "MontoCuota", "MontoPrestamo", "MontoTotal", "Mora", "NombreDeUsuario", "Nombres", "NumeroCuota", "NumeroDocumento", "Ocupacion", "Sexo", "SueldoMensual", "Telefono", "TipoDocumento", "TotalIntereses" },
                values: new object[] { 2, "Diaz", null, null, "72bfda8ad26e77fa13f7fbcbd15ca12877f62354c6e57ba27ce2bfcaa1a359f1", null, null, null, new DateTime(2021, 12, 6, 20, 57, 30, 167, DateTimeKind.Local).AddTicks(8909), null, 0f, null, 0f, 0f, 0f, 0, "Rdiaz", "Reny", 0, null, null, null, 0, null, null, 0f });

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_Prestamoid",
                table: "Cuota",
                column: "Prestamoid");

            migrationBuilder.CreateIndex(
                name: "IX_MorasDetalle_MoraId",
                table: "MorasDetalle",
                column: "MoraId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamoDetalle_ClientesCodigoCliente",
                table: "PrestamoDetalle",
                column: "ClientesCodigoCliente");

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
                name: "Cuota");

            migrationBuilder.DropTable(
                name: "MorasDetalle");

            migrationBuilder.DropTable(
                name: "PrestamoDetalle");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Moras");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
