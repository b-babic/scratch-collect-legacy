using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace scratch_collect.API.Migrations
{
    public partial class Coupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UsedById = table.Column<int>(type: "int", nullable: true),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Users_UsedById",
                        column: x => x.UsedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Text", "UsedById", "Value" },
                values: new object[,]
                {
                    { 1, "804C-4D13", null, 10 },
                    { 2, "4422-83E8", null, 15 },
                    { 3, "4492-BD28", null, 10 },
                    { 4, "497D-A613", 2, 30 },
                    { 5, "47E7-9714", 2, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UsedById",
                table: "Coupons",
                column: "UsedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}