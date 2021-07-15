using Microsoft.EntityFrameworkCore.Migrations;

namespace scratch_collect.API.Migrations
{
    public partial class UserToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lZjMPngWFTVkSHSrTDtHDBXuuB4=", "TFnNKEmsjdYcyDMXeYXLwQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "AT+j0mc/FSQSqhwwcGOAzTg6VbQ=", "6A/p2PwGYsrquhu1AK9eIw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "A94A8FE5CCB19BA61C4C0873D391E987982FBBD3", "uk9EEw-w9-sq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "A94A8FE5CCB19BA61C4C0873D391E987982FBBD3", "uk9EEw-w9-sq" });
        }
    }
}
