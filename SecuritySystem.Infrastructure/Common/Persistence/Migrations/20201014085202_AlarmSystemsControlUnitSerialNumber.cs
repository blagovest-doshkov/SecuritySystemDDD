using Microsoft.EntityFrameworkCore.Migrations;

namespace SecuritySystem.Infrastructure.Common.Persistence.Migrations
{
    public partial class AlarmSystemsControlUnitSerialNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ControlUnitSerialNumber",
                table: "AlarmSystems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ControlUnitSerialNumber",
                table: "AlarmSystems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
