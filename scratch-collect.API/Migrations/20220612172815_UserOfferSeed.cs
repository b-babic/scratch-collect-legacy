using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace scratch_collect.API.Migrations
{
    public partial class UserOfferSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserOffers",
                columns: new[] { "Id", "BoughtOn", "OfferId", "Played", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 2 },
                    { 2, new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, 2 },
                    { 3, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, 2 },
                    { 4, new DateTime(2021, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, false, 2 },
                    { 5, new DateTime(2021, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, false, 2 },
                    { 6, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserOffers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserOffers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserOffers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserOffers",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}