using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAreaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ReportaAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Areas_ReportaAId",
                        column: x => x.ReportaAId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ReportaAId",
                table: "Areas",
                column: "ReportaAId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
