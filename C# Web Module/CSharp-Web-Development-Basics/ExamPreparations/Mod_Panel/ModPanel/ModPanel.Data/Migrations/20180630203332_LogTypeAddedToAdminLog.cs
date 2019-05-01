using Microsoft.EntityFrameworkCore.Migrations;

namespace ModPanel.Data.Migrations
{
    public partial class LogTypeAddedToAdminLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LogType",
                table: "AdminLogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogType",
                table: "AdminLogs");
        }
    }
}
