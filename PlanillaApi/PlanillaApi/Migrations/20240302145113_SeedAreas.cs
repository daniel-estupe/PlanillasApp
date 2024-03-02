using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanillaApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into Areas (Descripcion) values ('Dirección de Servicios al Exportador');");
            migrationBuilder.Sql(@"
declare @areaId int
select @areaId = Id from Areas where Descripcion='Dirección de Servicios al Exportador';
insert into Areas (Descripcion,ReportaAId) values ('Informática',@areaId), ('Gestión VUPE-OPA', @areaId);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
declare @areaId int
select @areaId = Id from Areas where Descripcion='Dirección de Servicios al Exportador';
delete from Areas where Id=@areaId");
        }
    }
}
