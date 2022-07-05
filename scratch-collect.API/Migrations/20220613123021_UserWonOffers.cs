using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace scratch_collect.API.Migrations
{
    public partial class UserWonOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PlayedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Won",
                table: "UserOffers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "UserOffers",
                columns: new[] { "Id", "BoughtOn", "OfferId", "Played", "PlayedOn", "UserId", "Won" },
                values: new object[] { 7, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, true, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false });

            migrationBuilder.InsertData(
                table: "UserOffers",
                columns: new[] { "Id", "BoughtOn", "OfferId", "Played", "PlayedOn", "UserId", "Won" },
                values: new object[] { 8, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOffers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserOffers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "PlayedOn",
                table: "UserOffers");

            migrationBuilder.DropColumn(
                name: "Won",
                table: "UserOffers");
        }
    }
}