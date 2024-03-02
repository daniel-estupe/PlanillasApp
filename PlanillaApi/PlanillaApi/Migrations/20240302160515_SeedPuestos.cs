using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanillaApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedPuestos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
declare @areaId int
select @areaId = Id from Areas where Descripcion='Informática';
insert into Puestos (Descripcion, TechoSalarial, AreaId, PlazasHabilitadas)
values ('Ingeniero de proyectos', 25000, @areaId, 4), ('Arquitecto de software', 30000, @areaId, 2);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
declare @areaId int
select @areaId = Id from Areas where Descripcion='Informática';
delete from Puestos where AreaId=@areaId;
");
        }
    }
}
