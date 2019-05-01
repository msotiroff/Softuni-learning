using Microsoft.EntityFrameworkCore.Migrations;

namespace Judge.Data.Migrations
{
    public partial class CompiledColumnAddedToSubmissionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Compiled",
                table: "Submissions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Compiled",
                table: "Submissions");
        }
    }
}
