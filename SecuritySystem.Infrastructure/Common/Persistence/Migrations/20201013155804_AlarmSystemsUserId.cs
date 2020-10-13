using Microsoft.EntityFrameworkCore.Migrations;

namespace SecuritySystem.Infrastructure.Common.Persistence.Migrations
{
    public partial class AlarmSystemsUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "AlarmSystems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "AlarmSystems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
