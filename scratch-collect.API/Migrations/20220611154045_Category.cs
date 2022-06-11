using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scratch_collect.API.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GradientStart = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    GradientStop = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "GradientStart", "GradientStop", "Name" },
                values: new object[,]
                {
                    { 1, "#BDC3C7", "#2C3E50", "Luxury" },
                    { 2, "#36D1DC", "#5B86E5", "Sports" },
                    { 3, "#DAD299", "#B0DAB9", "Food" },
                    { 4, "#E1EEC3", "#F05053", "Travel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}