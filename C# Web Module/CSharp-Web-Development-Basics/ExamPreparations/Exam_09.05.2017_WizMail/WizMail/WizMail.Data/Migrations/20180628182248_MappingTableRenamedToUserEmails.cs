using Microsoft.EntityFrameworkCore.Migrations;

namespace WizMail.Data.Migrations
{
    public partial class MappingTableRenamedToUserEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Flags_FlagId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmail_Emails_EmailId",
                table: "UserEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmail_Users_RecipientId",
                table: "UserEmail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEmail",
                table: "UserEmail");

            migrationBuilder.RenameTable(
                name: "UserEmail",
                newName: "UserEmails");

            migrationBuilder.RenameIndex(
                name: "IX_UserEmail_RecipientId",
                table: "UserEmails",
                newName: "IX_UserEmails_RecipientId");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlagId",
                table: "Emails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEmails",
                table: "UserEmails",
                columns: new[] { "EmailId", "RecipientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Flags_FlagId",
                table: "Emails",
                column: "FlagId",
                principalTable: "Flags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmails_Emails_EmailId",
                table: "UserEmails",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmails_Users_RecipientId",
                table: "UserEmails",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Flags_FlagId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmails_Emails_EmailId",
                table: "UserEmails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmails_Users_RecipientId",
                table: "UserEmails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEmails",
                table: "UserEmails");

            migrationBuilder.RenameTable(
                name: "UserEmails",
                newName: "UserEmail");

            migrationBuilder.RenameIndex(
                name: "IX_UserEmails_RecipientId",
                table: "UserEmail",
                newName: "IX_UserEmail_RecipientId");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "FlagId",
                table: "Emails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEmail",
                table: "UserEmail",
                columns: new[] { "EmailId", "RecipientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Flags_FlagId",
                table: "Emails",
                column: "FlagId",
                principalTable: "Flags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmail_Emails_EmailId",
                table: "UserEmail",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmail_Users_RecipientId",
                table: "UserEmail",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
