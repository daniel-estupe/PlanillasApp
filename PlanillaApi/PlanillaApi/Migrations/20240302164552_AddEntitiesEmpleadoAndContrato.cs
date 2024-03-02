using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitiesEmpleadoAndContrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CUI = table.Column<string>(type: "nchar(13)", fixedLength: true, maxLength: 13, nullable: false),
                    NIT = table.Column<string>(type: "nchar(13)", fixedLength: true, maxLength: 13, nullable: false),
                    Pasaporte = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    AfiliacionIGSS = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    AfiliacionIRTRA = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    FechaAfiliacionIRTRA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    SalarioBase = table.Column<decimal>(type: "MONEY", nullable: false),
                    Bonificacion = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_EmpleadoId",
                table: "Contratos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PuestoId",
                table: "Contratos",
                column: "PuestoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
