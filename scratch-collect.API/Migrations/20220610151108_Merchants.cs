using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace scratch_collect.API.Migrations
{
    public partial class Merchants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "Address", "CreatedAt", "Name", "Telephone" },
                values: new object[,]
                {
                    { 1, "3899 Forest Avenue", new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "Altria Group", "646-836-5972" },
                    { 2, "2610 Apple Lane", new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "Halliburton", "309-343-8619" },
                    { 3, "2833 Winifred Way", new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "Aramark", "765-676-8245" },
                    { 4, "189 Desert Broom Court", new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "DISH Network", "201-705-6273" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchants");
        }
    }
}