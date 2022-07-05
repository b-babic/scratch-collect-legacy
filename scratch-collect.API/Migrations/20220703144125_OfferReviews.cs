using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace scratch_collect.API.Migrations
{
    public partial class OfferReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateCount = table.Column<double>(type: "float", nullable: false),
                    RatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "RateCount", "OfferId", "UserId", "RatedOn" },
                values: new object[,]
                {
                    { 1, 3.0, 1, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4.0, 1, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3.0, 2, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4.0, 2, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5.0, 3, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6,  4.0, 3, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4.0, 4, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4.0, 4, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 5.0, 5, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10,4.0, 5, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 5.0, 6, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 5.0, 6, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 2.0, 7, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 3.0, 7, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2.0, 8, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16,  4.0, 8, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17,  5.0, 9, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18,  4.0, 9, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19,  5.0, 10, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20,  4.0, 10, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21,  2.0, 11, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22,  4.0, 11, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 5.0, 12, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24,  5.0, 12, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25,  5.0, 13, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26,  5.0, 13, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27,  1.0, 14, 1, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28,  2.0, 14, 2, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OfferId",
                table: "Ratings",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}