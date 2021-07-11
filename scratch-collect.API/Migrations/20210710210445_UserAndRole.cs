﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scratch_collect.API.Migrations
{
    public partial class UserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator role", "Administrator" },
                    { 2, "Client role", "Client" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RegisteredAt", "UserPhoto", "Username" },
                values: new object[,]
                {
                    { 1, "Hogwarts 10", "desktop@test.com", "John", "Doe", "lZjMPngWFTVkSHSrTDtHDBXuuB4=", "TFnNKEmsjdYcyDMXeYXLwQ==", new DateTime(2020, 8, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 2, 0, 0, 0, 2, 0, 8, 3, 0, 0, 0, 195, 166, 36, 200, 0, 0, 0, 33, 80, 76, 84, 69, 76, 105, 113, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 155, 45, 34, 217, 0, 0, 0, 10, 116, 82, 78, 83, 0, 23, 240, 165, 48, 79, 138, 111, 219, 196, 176, 138, 215, 89, 0, 0, 9, 112, 73, 68, 65, 84, 120, 218, 237, 221, 9, 114, 235, 214, 14, 132, 225, 203, 121, 216, 255, 130, 95, 37, 55, 201, 155, 108, 89, 20, 15, 135, 195, 254, 254, 5, 184, 84, 2, 4, 116, 3, 32, 253, 235, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 127, 211, 52, 125, 63, 12, 211, 52, 141, 227, 52, 77, 195, 208, 247, 77, 227, 91, 137, 136, 252, 48, 117, 75, 187, 126, 73, 187, 116, 211, 32, 15, 158, 27, 250, 177, 155, 215, 55, 152, 187, 81, 26, 60, 47, 248, 203, 186, 137, 69, 18, 60, 134, 126, 107, 240, 255, 157, 4, 189, 111, 175, 118, 134, 174, 93, 119, 208, 118, 131, 239, 176, 230, 223, 254, 174, 232, 255, 149, 3, 234, 64, 165, 125, 127, 154, 215, 66, 204, 19, 61, 80, 27, 211, 178, 22, 101, 153, 124, 167, 53, 133, 127, 94, 139, 51, 75, 129, 106, 106, 127, 187, 30, 66, 171, 19, 212, 16, 254, 241, 160, 240, 255, 22, 132, 82, 32, 56, 252, 82, 224, 254, 189, 255, 224, 240, 255, 78, 1, 223, 243, 93, 135, 62, 243, 122, 10, 179, 225, 208, 45, 171, 127, 183, 158, 70, 167, 15, 68, 86, 255, 255, 52, 4, 190, 241, 91, 209, 207, 235, 201, 232, 3, 119, 162, 91, 47, 64, 31, 200, 253, 249, 255, 85, 4, 108, 137, 2, 187, 63, 37, 160, 252, 107, 3, 202, 191, 54, 16, 95, 254, 181, 129, 248, 242, 255, 79, 27, 16, 135, 171, 88, 214, 91, 176, 136, 196, 37, 52, 55, 137, 255, 186, 46, 164, 224, 21, 241, 159, 215, 219, 48, 203, 128, 56, 249, 207, 12, 92, 28, 255, 118, 189, 21, 173, 12, 56, 149, 225, 102, 241, 95, 215, 214, 114, 232, 204, 248, 175, 55, 68, 6, 196, 214, 127, 93, 64, 252, 101, 64, 166, 255, 227, 6, 197, 95, 6, 100, 206, 127, 77, 133, 197, 95, 6, 92, 64, 183, 222, 28, 187, 193, 67, 153, 214, 219, 227, 62, 224, 72, 3, 184, 86, 0, 51, 24, 105, 0, 88, 1, 2, 128, 12, 32, 0, 200, 128, 192, 9, 176, 153, 48, 1, 64, 6, 16, 0, 100, 192, 193, 12, 107, 85, 56, 14, 40, 205, 92, 87, 2, 204, 34, 22, 234, 0, 56, 129, 99, 20, 96, 91, 91, 2, 180, 116, 96, 172, 2, 164, 3, 211, 21, 32, 29, 24, 174, 0, 233, 192, 194, 140, 107, 149, 120, 163, 100, 41, 5, 184, 86, 10, 29, 24, 93, 0, 148, 128, 88, 11, 200, 10, 42, 0, 74, 128, 2, 160, 4, 196, 23, 0, 37, 32, 188, 0, 40, 1, 5, 152, 214, 170, 177, 19, 218, 75, 91, 119, 2, 180, 34, 24, 93, 0, 148, 128, 189, 44, 181, 39, 128, 135, 5, 119, 209, 175, 213, 227, 66, 56, 214, 3, 114, 130, 251, 153, 235, 79, 0, 91, 225, 236, 14, 160, 7, 236, 161, 123, 66, 2, 184, 13, 139, 29, 2, 24, 5, 236, 100, 88, 31, 129, 227, 192, 232, 14, 160, 7, 124, 206, 250, 16, 68, 50, 186, 3, 232, 1, 193, 83, 32, 179, 160, 232, 61, 128, 125, 192, 46, 154, 245, 49, 56, 11, 137, 150, 0, 68, 64, 184, 4, 32, 2, 98, 23, 65, 22, 66, 36, 0, 17, 64, 2, 16, 1, 233, 18, 128, 8, 8, 94, 4, 88, 7, 208, 128, 84, 96, 244, 38, 200, 62, 232, 51, 250, 103, 37, 128, 187, 176, 104, 19, 192, 6, 108, 103, 122, 86, 2, 120, 64, 40, 218, 4, 176, 1, 219, 89, 158, 149, 0, 54, 194, 91, 105, 159, 149, 0, 78, 131, 147, 55, 1, 182, 1, 18, 64, 2, 100, 143, 1, 12, 2, 36, 128, 152, 38, 207, 129, 76, 130, 36, 128, 152, 74, 0, 196, 78, 130, 205, 130, 37, 128, 152, 110, 98, 124, 90, 2, 56, 10, 147, 0, 144, 0, 144, 0, 32, 2, 33, 1, 32, 1, 96, 18, 8, 9, 0, 9, 128, 47, 112, 15, 32, 1, 36, 64, 52, 79, 75, 0, 17, 221, 200, 252, 172, 248, 123, 60, 120, 43, 30, 12, 9, 199, 163, 97, 182, 65, 118, 65, 6, 1, 198, 0, 124, 32, 23, 152, 201, 195, 158, 13, 243, 100, 216, 102, 30, 245, 120, 176, 135, 131, 195, 125, 32, 23, 24, 110, 3, 152, 128, 112, 27, 192, 4, 132, 171, 64, 26, 48, 123, 27, 96, 19, 16, 62, 12, 54, 8, 254, 132, 7, 221, 133, 186, 8, 13, 159, 5, 154, 3, 102, 139, 0, 18, 32, 124, 18, 96, 10, 16, 62, 9, 48, 5, 200, 94, 7, 88, 4, 132, 27, 65, 38, 48, 188, 7, 232, 0, 217, 61, 64, 7, 8, 239, 1, 58, 64, 120, 15, 208, 1, 178, 123, 128, 14, 16, 62, 11, 50, 5, 10, 223, 7, 216, 3, 236, 162, 250, 203, 64, 215, 128, 225, 50, 144, 4, 204, 150, 129, 36, 96, 184, 12, 36, 1, 247, 82, 249, 109, 168, 107, 208, 236, 105, 160, 41, 96, 120, 9, 80, 0, 178, 85, 0, 5, 80, 164, 4, 84, 107, 4, 90, 5, 32, 187, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 202, 81, 229, 83, 98, 158, 7, 43, 72, 133, 75, 65, 107, 192, 146, 84, 120, 23, 224, 14, 32, 91, 7, 82, 128, 133, 169, 236, 73, 81, 207, 131, 150, 166, 178, 203, 16, 119, 32, 197, 169, 106, 43, 104, 11, 120, 192, 48, 160, 162, 38, 48, 27, 1, 100, 59, 1, 14, 32, 123, 28, 100, 4, 148, 45, 3, 8, 128, 108, 25, 64, 0, 132, 203, 0, 2, 32, 91, 6, 16, 0, 217, 50, 128, 0, 200, 206, 0, 241, 63, 156, 91, 111, 134, 237, 128, 179, 173, 0, 3, 112, 74, 6, 220, 246, 64, 204, 17, 216, 73, 102, 240, 166, 25, 208, 50, 128, 209, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 167, 103, 192, 173, 220, 224, 44, 254, 209, 243, 0, 254, 255, 146, 12, 184, 205, 76, 112, 17, 255, 107, 184, 201, 94, 192, 252, 255, 50, 110, 177, 29, 182, 255, 189, 144, 225, 114, 51, 208, 122, 2, 32, 218, 12, 144, 255, 151, 75, 193, 75, 133, 64, 71, 254, 221, 64, 8, 92, 214, 6, 90, 237, 255, 204, 159, 250, 216, 220, 204, 15, 126, 235, 254, 190, 255, 168, 216, 243, 59, 255, 126, 220, 58, 221, 234, 231, 223, 183, 106, 67, 113, 181, 63, 191, 86, 220, 253, 233, 69, 96, 233, 95, 59, 147, 153, 59, 40, 40, 245, 255, 9, 239, 247, 223, 234, 201, 111, 144, 248, 254, 253, 15, 195, 207, 41, 130, 207, 117, 254, 244, 235, 14, 69, 224, 69, 108, 39, 30, 225, 88, 145, 63, 254, 212, 39, 78, 240, 254, 47, 170, 251, 200, 38, 28, 61, 232, 233, 46, 118, 132, 47, 131, 218, 25, 20, 149, 101, 220, 184, 123, 105, 198, 131, 83, 160, 125, 233, 240, 186, 77, 106, 1, 239, 105, 255, 109, 219, 215, 99, 39, 131, 47, 187, 250, 55, 243, 8, 126, 160, 248, 144, 247, 245, 2, 230, 176, 42, 240, 250, 215, 255, 98, 49, 69, 12, 126, 244, 243, 111, 63, 114, 97, 127, 166, 192, 116, 128, 28, 156, 167, 102, 115, 183, 178, 50, 60, 224, 231, 255, 222, 17, 206, 80, 216, 20, 46, 63, 132, 240, 167, 113, 180, 34, 80, 240, 231, 255, 222, 143, 170, 239, 138, 117, 130, 182, 235, 143, 255, 188, 216, 58, 214, 251, 89, 94, 15, 37, 114, 160, 237, 134, 179, 62, 47, 222, 43, 167, 91, 110, 49, 119, 230, 192, 59, 209, 47, 250, 121, 177, 229, 204, 235, 173, 65, 91, 51, 116, 31, 74, 194, 185, 27, 222, 9, 217, 251, 211, 39, 109, 224, 29, 54, 249, 248, 55, 7, 109, 219, 147, 224, 205, 224, 111, 189, 73, 211, 6, 202, 126, 159, 91, 228, 117, 51, 140, 203, 91, 191, 213, 118, 25, 135, 183, 255, 232, 214, 177, 147, 21, 97, 169, 242, 255, 217, 194, 165, 233, 135, 177, 251, 46, 15, 218, 165, 27, 135, 126, 75, 163, 254, 96, 247, 160, 13, 236, 86, 211, 5, 126, 85, 77, 223, 15, 195, 48, 77, 227, 216, 117, 227, 56, 77, 195, 48, 244, 253, 102, 137, 246, 225, 2, 218, 134, 176, 76, 251, 255, 175, 214, 122, 129, 190, 110, 62, 62, 65, 241, 36, 209, 62, 55, 245, 117, 31, 56, 57, 5, 154, 61, 155, 103, 126, 240, 203, 130, 186, 111, 104, 211, 158, 89, 5, 246, 238, 155, 92, 9, 20, 145, 127, 87, 165, 64, 129, 117, 35, 41, 88, 70, 254, 93, 145, 2, 133, 182, 205, 38, 2, 101, 228, 223, 255, 9, 172, 131, 139, 107, 95, 238, 147, 138, 250, 1, 241, 255, 227, 139, 61, 176, 186, 14, 69, 63, 168, 184, 23, 144, 255, 159, 109, 111, 63, 252, 241, 23, 190, 52, 98, 6, 142, 137, 255, 159, 50, 187, 180, 26, 104, 198, 3, 142, 140, 100, 192, 175, 3, 95, 246, 180, 148, 27, 13, 52, 211, 65, 15, 157, 120, 185, 212, 177, 111, 120, 232, 166, 2, 189, 160, 159, 14, 188, 51, 54, 16, 56, 250, 133, 143, 237, 174, 36, 232, 167, 238, 232, 207, 215, 139, 255, 241, 143, 114, 117, 159, 116, 131, 102, 234, 206, 120, 212, 44, 59, 3, 206, 123, 225, 235, 220, 141, 211, 187, 251, 190, 166, 159, 198, 238, 180, 119, 15, 37, 103, 192, 233, 47, 252, 109, 151, 110, 26, 94, 124, 225, 253, 48, 117, 203, 233, 31, 170, 23, 255, 179, 191, 242, 121, 94, 150, 191, 47, 1, 126, 95, 5, 44, 203, 60, 95, 246, 113, 66, 51, 160, 166, 127, 7, 126, 112, 127, 106, 196, 95, 6, 136, 191, 12, 48, 255, 205, 37, 110, 42, 44, 254, 255, 155, 1, 89, 241, 239, 68, 60, 122, 59, 60, 138, 119, 244, 141, 208, 32, 218, 95, 17, 115, 39, 216, 139, 245, 215, 132, 12, 132, 238, 251, 191, 127, 175, 38, 227, 127, 15, 27, 0, 132, 143, 3, 24, 192, 108, 51, 200, 0, 100, 91, 1, 6, 32, 219, 10, 244, 4, 224, 79, 66, 240, 217, 86, 128, 0, 252, 89, 8, 154, 0, 155, 9, 63, 149, 73, 116, 163, 101, 0, 1, 144, 45, 3, 76, 128, 194, 101, 0, 1, 144, 45, 3, 8, 128, 108, 25, 96, 5, 20, 190, 22, 178, 2, 200, 110, 2, 26, 64, 118, 19, 208, 0, 194, 155, 0, 7, 144, 221, 4, 236, 0, 179, 155, 128, 6, 16, 222, 4, 52, 128, 236, 38, 160, 1, 132, 55, 1, 59, 128, 236, 157, 128, 43, 192, 143, 25, 41, 64, 58, 144, 2, 164, 3, 41, 64, 58, 144, 2, 164, 3, 45, 129, 34, 153, 40, 64, 58, 144, 5, 100, 5, 43, 197, 155, 0, 10, 80, 243, 141, 48, 11, 152, 109, 5, 21, 128, 240, 18, 160, 0, 100, 151, 0, 5, 32, 188, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 194, 75, 128, 2, 144, 93, 2, 26, 81, 43, 73, 125, 27, 1, 91, 128, 240, 141, 128, 53, 96, 81, 90, 119, 0, 225, 212, 118, 23, 224, 16, 168, 48, 149, 157, 6, 185, 4, 44, 78, 93, 215, 129, 60, 96, 182, 19, 228, 1, 195, 157, 32, 15, 24, 238, 4, 121, 192, 108, 39, 200, 3, 134, 59, 65, 111, 4, 59, 132, 133, 4, 36, 3, 117, 0, 61, 192, 20, 208, 52, 208, 37, 72, 40, 117, 220, 133, 24, 2, 132, 143, 2, 116, 128, 236, 30, 96, 15, 116, 32, 53, 108, 132, 236, 129, 14, 164, 134, 141, 144, 49, 112, 246, 56, 88, 7, 8, 239, 1, 60, 64, 184, 15, 224, 1, 178, 125, 128, 41, 80, 248, 44, 200, 30, 224, 96, 238, 190, 15, 176, 9, 62, 152, 155, 239, 132, 109, 130, 15, 231, 222, 59, 97, 38, 48, 220, 8, 26, 3, 134, 15, 3, 141, 1, 179, 135, 129, 76, 96, 184, 17, 100, 2, 195, 141, 32, 9, 16, 46, 2, 204, 129, 179, 167, 193, 166, 0, 225, 147, 0, 83, 128, 240, 73, 128, 85, 240, 41, 220, 119, 37, 108, 17, 112, 10, 247, 93, 7, 136, 205, 57, 24, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 209, 128, 84, 32, 13, 72, 5, 154, 3, 154, 5, 50, 1, 108, 0, 19, 192, 6, 24, 4, 27, 6, 187, 7, 124, 62, 183, 188, 11, 116, 12, 112, 34, 13, 19, 192, 6, 48, 1, 108, 128, 107, 144, 84, 70, 9, 32, 1, 36, 128, 4, 160, 1, 104, 0, 46, 128, 11, 184, 203, 28, 192, 32, 232, 188, 65, 208, 45, 31, 13, 176, 11, 56, 141, 123, 238, 2, 220, 3, 156, 198, 77, 175, 66, 249, 128, 96, 15, 96, 31, 120, 30, 247, 125, 48, 164, 145, 1, 103, 196, 255, 198, 175, 137, 146, 1, 217, 241, 255, 99, 28, 196, 12, 30, 107, 0, 111, 255, 143, 163, 154, 78, 10, 28, 23, 254, 174, 138, 255, 28, 55, 140, 203, 44, 11, 74, 199, 126, 94, 198, 186, 254, 131, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 247, 231, 95, 23, 190, 217, 98, 181, 249, 103, 109, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "desktop" },
                    { 2, "Hogwarts 11", "mobile@test.com", "Jane", "Doe", "AT+j0mc/FSQSqhwwcGOAzTg6VbQ=", "6A/p2PwGYsrquhu1AK9eIw==", new DateTime(2020, 9, 7, 22, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 2, 0, 0, 0, 2, 0, 8, 3, 0, 0, 0, 195, 166, 36, 200, 0, 0, 0, 33, 80, 76, 84, 69, 76, 105, 113, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 155, 45, 34, 217, 0, 0, 0, 10, 116, 82, 78, 83, 0, 23, 240, 165, 48, 79, 138, 111, 219, 196, 176, 138, 215, 89, 0, 0, 9, 112, 73, 68, 65, 84, 120, 218, 237, 221, 9, 114, 235, 214, 14, 132, 225, 203, 121, 216, 255, 130, 95, 37, 55, 201, 155, 108, 89, 20, 15, 135, 195, 254, 254, 5, 184, 84, 2, 4, 116, 3, 32, 253, 235, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 127, 211, 52, 125, 63, 12, 211, 52, 141, 227, 52, 77, 195, 208, 247, 77, 227, 91, 137, 136, 252, 48, 117, 75, 187, 126, 73, 187, 116, 211, 32, 15, 158, 27, 250, 177, 155, 215, 55, 152, 187, 81, 26, 60, 47, 248, 203, 186, 137, 69, 18, 60, 134, 126, 107, 240, 255, 157, 4, 189, 111, 175, 118, 134, 174, 93, 119, 208, 118, 131, 239, 176, 230, 223, 254, 174, 232, 255, 149, 3, 234, 64, 165, 125, 127, 154, 215, 66, 204, 19, 61, 80, 27, 211, 178, 22, 101, 153, 124, 167, 53, 133, 127, 94, 139, 51, 75, 129, 106, 106, 127, 187, 30, 66, 171, 19, 212, 16, 254, 241, 160, 240, 255, 22, 132, 82, 32, 56, 252, 82, 224, 254, 189, 255, 224, 240, 255, 78, 1, 223, 243, 93, 135, 62, 243, 122, 10, 179, 225, 208, 45, 171, 127, 183, 158, 70, 167, 15, 68, 86, 255, 255, 52, 4, 190, 241, 91, 209, 207, 235, 201, 232, 3, 119, 162, 91, 47, 64, 31, 200, 253, 249, 255, 85, 4, 108, 137, 2, 187, 63, 37, 160, 252, 107, 3, 202, 191, 54, 16, 95, 254, 181, 129, 248, 242, 255, 79, 27, 16, 135, 171, 88, 214, 91, 176, 136, 196, 37, 52, 55, 137, 255, 186, 46, 164, 224, 21, 241, 159, 215, 219, 48, 203, 128, 56, 249, 207, 12, 92, 28, 255, 118, 189, 21, 173, 12, 56, 149, 225, 102, 241, 95, 215, 214, 114, 232, 204, 248, 175, 55, 68, 6, 196, 214, 127, 93, 64, 252, 101, 64, 166, 255, 227, 6, 197, 95, 6, 100, 206, 127, 77, 133, 197, 95, 6, 92, 64, 183, 222, 28, 187, 193, 67, 153, 214, 219, 227, 62, 224, 72, 3, 184, 86, 0, 51, 24, 105, 0, 88, 1, 2, 128, 12, 32, 0, 200, 128, 192, 9, 176, 153, 48, 1, 64, 6, 16, 0, 100, 192, 193, 12, 107, 85, 56, 14, 40, 205, 92, 87, 2, 204, 34, 22, 234, 0, 56, 129, 99, 20, 96, 91, 91, 2, 180, 116, 96, 172, 2, 164, 3, 211, 21, 32, 29, 24, 174, 0, 233, 192, 194, 140, 107, 149, 120, 163, 100, 41, 5, 184, 86, 10, 29, 24, 93, 0, 148, 128, 88, 11, 200, 10, 42, 0, 74, 128, 2, 160, 4, 196, 23, 0, 37, 32, 188, 0, 40, 1, 5, 152, 214, 170, 177, 19, 218, 75, 91, 119, 2, 180, 34, 24, 93, 0, 148, 128, 189, 44, 181, 39, 128, 135, 5, 119, 209, 175, 213, 227, 66, 56, 214, 3, 114, 130, 251, 153, 235, 79, 0, 91, 225, 236, 14, 160, 7, 236, 161, 123, 66, 2, 184, 13, 139, 29, 2, 24, 5, 236, 100, 88, 31, 129, 227, 192, 232, 14, 160, 7, 124, 206, 250, 16, 68, 50, 186, 3, 232, 1, 193, 83, 32, 179, 160, 232, 61, 128, 125, 192, 46, 154, 245, 49, 56, 11, 137, 150, 0, 68, 64, 184, 4, 32, 2, 98, 23, 65, 22, 66, 36, 0, 17, 64, 2, 16, 1, 233, 18, 128, 8, 8, 94, 4, 88, 7, 208, 128, 84, 96, 244, 38, 200, 62, 232, 51, 250, 103, 37, 128, 187, 176, 104, 19, 192, 6, 108, 103, 122, 86, 2, 120, 64, 40, 218, 4, 176, 1, 219, 89, 158, 149, 0, 54, 194, 91, 105, 159, 149, 0, 78, 131, 147, 55, 1, 182, 1, 18, 64, 2, 100, 143, 1, 12, 2, 36, 128, 152, 38, 207, 129, 76, 130, 36, 128, 152, 74, 0, 196, 78, 130, 205, 130, 37, 128, 152, 110, 98, 124, 90, 2, 56, 10, 147, 0, 144, 0, 144, 0, 32, 2, 33, 1, 32, 1, 96, 18, 8, 9, 0, 9, 128, 47, 112, 15, 32, 1, 36, 64, 52, 79, 75, 0, 17, 221, 200, 252, 172, 248, 123, 60, 120, 43, 30, 12, 9, 199, 163, 97, 182, 65, 118, 65, 6, 1, 198, 0, 124, 32, 23, 152, 201, 195, 158, 13, 243, 100, 216, 102, 30, 245, 120, 176, 135, 131, 195, 125, 32, 23, 24, 110, 3, 152, 128, 112, 27, 192, 4, 132, 171, 64, 26, 48, 123, 27, 96, 19, 16, 62, 12, 54, 8, 254, 132, 7, 221, 133, 186, 8, 13, 159, 5, 154, 3, 102, 139, 0, 18, 32, 124, 18, 96, 10, 16, 62, 9, 48, 5, 200, 94, 7, 88, 4, 132, 27, 65, 38, 48, 188, 7, 232, 0, 217, 61, 64, 7, 8, 239, 1, 58, 64, 120, 15, 208, 1, 178, 123, 128, 14, 16, 62, 11, 50, 5, 10, 223, 7, 216, 3, 236, 162, 250, 203, 64, 215, 128, 225, 50, 144, 4, 204, 150, 129, 36, 96, 184, 12, 36, 1, 247, 82, 249, 109, 168, 107, 208, 236, 105, 160, 41, 96, 120, 9, 80, 0, 178, 85, 0, 5, 80, 164, 4, 84, 107, 4, 90, 5, 32, 187, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 202, 81, 229, 83, 98, 158, 7, 43, 72, 133, 75, 65, 107, 192, 146, 84, 120, 23, 224, 14, 32, 91, 7, 82, 128, 133, 169, 236, 73, 81, 207, 131, 150, 166, 178, 203, 16, 119, 32, 197, 169, 106, 43, 104, 11, 120, 192, 48, 160, 162, 38, 48, 27, 1, 100, 59, 1, 14, 32, 123, 28, 100, 4, 148, 45, 3, 8, 128, 108, 25, 64, 0, 132, 203, 0, 2, 32, 91, 6, 16, 0, 217, 50, 128, 0, 200, 206, 0, 241, 63, 156, 91, 111, 134, 237, 128, 179, 173, 0, 3, 112, 74, 6, 220, 246, 64, 204, 17, 216, 73, 102, 240, 166, 25, 208, 50, 128, 209, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 167, 103, 192, 173, 220, 224, 44, 254, 209, 243, 0, 254, 255, 146, 12, 184, 205, 76, 112, 17, 255, 107, 184, 201, 94, 192, 252, 255, 50, 110, 177, 29, 182, 255, 189, 144, 225, 114, 51, 208, 122, 2, 32, 218, 12, 144, 255, 151, 75, 193, 75, 133, 64, 71, 254, 221, 64, 8, 92, 214, 6, 90, 237, 255, 204, 159, 250, 216, 220, 204, 15, 126, 235, 254, 190, 255, 168, 216, 243, 59, 255, 126, 220, 58, 221, 234, 231, 223, 183, 106, 67, 113, 181, 63, 191, 86, 220, 253, 233, 69, 96, 233, 95, 59, 147, 153, 59, 40, 40, 245, 255, 9, 239, 247, 223, 234, 201, 111, 144, 248, 254, 253, 15, 195, 207, 41, 130, 207, 117, 254, 244, 235, 14, 69, 224, 69, 108, 39, 30, 225, 88, 145, 63, 254, 212, 39, 78, 240, 254, 47, 170, 251, 200, 38, 28, 61, 232, 233, 46, 118, 132, 47, 131, 218, 25, 20, 149, 101, 220, 184, 123, 105, 198, 131, 83, 160, 125, 233, 240, 186, 77, 106, 1, 239, 105, 255, 109, 219, 215, 99, 39, 131, 47, 187, 250, 55, 243, 8, 126, 160, 248, 144, 247, 245, 2, 230, 176, 42, 240, 250, 215, 255, 98, 49, 69, 12, 126, 244, 243, 111, 63, 114, 97, 127, 166, 192, 116, 128, 28, 156, 167, 102, 115, 183, 178, 50, 60, 224, 231, 255, 222, 17, 206, 80, 216, 20, 46, 63, 132, 240, 167, 113, 180, 34, 80, 240, 231, 255, 222, 143, 170, 239, 138, 117, 130, 182, 235, 143, 255, 188, 216, 58, 214, 251, 89, 94, 15, 37, 114, 160, 237, 134, 179, 62, 47, 222, 43, 167, 91, 110, 49, 119, 230, 192, 59, 209, 47, 250, 121, 177, 229, 204, 235, 173, 65, 91, 51, 116, 31, 74, 194, 185, 27, 222, 9, 217, 251, 211, 39, 109, 224, 29, 54, 249, 248, 55, 7, 109, 219, 147, 224, 205, 224, 111, 189, 73, 211, 6, 202, 126, 159, 91, 228, 117, 51, 140, 203, 91, 191, 213, 118, 25, 135, 183, 255, 232, 214, 177, 147, 21, 97, 169, 242, 255, 217, 194, 165, 233, 135, 177, 251, 46, 15, 218, 165, 27, 135, 126, 75, 163, 254, 96, 247, 160, 13, 236, 86, 211, 5, 126, 85, 77, 223, 15, 195, 48, 77, 227, 216, 117, 227, 56, 77, 195, 48, 244, 253, 102, 137, 246, 225, 2, 218, 134, 176, 76, 251, 255, 175, 214, 122, 129, 190, 110, 62, 62, 65, 241, 36, 209, 62, 55, 245, 117, 31, 56, 57, 5, 154, 61, 155, 103, 126, 240, 203, 130, 186, 111, 104, 211, 158, 89, 5, 246, 238, 155, 92, 9, 20, 145, 127, 87, 165, 64, 129, 117, 35, 41, 88, 70, 254, 93, 145, 2, 133, 182, 205, 38, 2, 101, 228, 223, 255, 9, 172, 131, 139, 107, 95, 238, 147, 138, 250, 1, 241, 255, 227, 139, 61, 176, 186, 14, 69, 63, 168, 184, 23, 144, 255, 159, 109, 111, 63, 252, 241, 23, 190, 52, 98, 6, 142, 137, 255, 159, 50, 187, 180, 26, 104, 198, 3, 142, 140, 100, 192, 175, 3, 95, 246, 180, 148, 27, 13, 52, 211, 65, 15, 157, 120, 185, 212, 177, 111, 120, 232, 166, 2, 189, 160, 159, 14, 188, 51, 54, 16, 56, 250, 133, 143, 237, 174, 36, 232, 167, 238, 232, 207, 215, 139, 255, 241, 143, 114, 117, 159, 116, 131, 102, 234, 206, 120, 212, 44, 59, 3, 206, 123, 225, 235, 220, 141, 211, 187, 251, 190, 166, 159, 198, 238, 180, 119, 15, 37, 103, 192, 233, 47, 252, 109, 151, 110, 26, 94, 124, 225, 253, 48, 117, 203, 233, 31, 170, 23, 255, 179, 191, 242, 121, 94, 150, 191, 47, 1, 126, 95, 5, 44, 203, 60, 95, 246, 113, 66, 51, 160, 166, 127, 7, 126, 112, 127, 106, 196, 95, 6, 136, 191, 12, 48, 255, 205, 37, 110, 42, 44, 254, 255, 155, 1, 89, 241, 239, 68, 60, 122, 59, 60, 138, 119, 244, 141, 208, 32, 218, 95, 17, 115, 39, 216, 139, 245, 215, 132, 12, 132, 238, 251, 191, 127, 175, 38, 227, 127, 15, 27, 0, 132, 143, 3, 24, 192, 108, 51, 200, 0, 100, 91, 1, 6, 32, 219, 10, 244, 4, 224, 79, 66, 240, 217, 86, 128, 0, 252, 89, 8, 154, 0, 155, 9, 63, 149, 73, 116, 163, 101, 0, 1, 144, 45, 3, 76, 128, 194, 101, 0, 1, 144, 45, 3, 8, 128, 108, 25, 96, 5, 20, 190, 22, 178, 2, 200, 110, 2, 26, 64, 118, 19, 208, 0, 194, 155, 0, 7, 144, 221, 4, 236, 0, 179, 155, 128, 6, 16, 222, 4, 52, 128, 236, 38, 160, 1, 132, 55, 1, 59, 128, 236, 157, 128, 43, 192, 143, 25, 41, 64, 58, 144, 2, 164, 3, 41, 64, 58, 144, 2, 164, 3, 45, 129, 34, 153, 40, 64, 58, 144, 5, 100, 5, 43, 197, 155, 0, 10, 80, 243, 141, 48, 11, 152, 109, 5, 21, 128, 240, 18, 160, 0, 100, 151, 0, 5, 32, 188, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 194, 75, 128, 2, 144, 93, 2, 26, 81, 43, 73, 125, 27, 1, 91, 128, 240, 141, 128, 53, 96, 81, 90, 119, 0, 225, 212, 118, 23, 224, 16, 168, 48, 149, 157, 6, 185, 4, 44, 78, 93, 215, 129, 60, 96, 182, 19, 228, 1, 195, 157, 32, 15, 24, 238, 4, 121, 192, 108, 39, 200, 3, 134, 59, 65, 111, 4, 59, 132, 133, 4, 36, 3, 117, 0, 61, 192, 20, 208, 52, 208, 37, 72, 40, 117, 220, 133, 24, 2, 132, 143, 2, 116, 128, 236, 30, 96, 15, 116, 32, 53, 108, 132, 236, 129, 14, 164, 134, 141, 144, 49, 112, 246, 56, 88, 7, 8, 239, 1, 60, 64, 184, 15, 224, 1, 178, 125, 128, 41, 80, 248, 44, 200, 30, 224, 96, 238, 190, 15, 176, 9, 62, 152, 155, 239, 132, 109, 130, 15, 231, 222, 59, 97, 38, 48, 220, 8, 26, 3, 134, 15, 3, 141, 1, 179, 135, 129, 76, 96, 184, 17, 100, 2, 195, 141, 32, 9, 16, 46, 2, 204, 129, 179, 167, 193, 166, 0, 225, 147, 0, 83, 128, 240, 73, 128, 85, 240, 41, 220, 119, 37, 108, 17, 112, 10, 247, 93, 7, 136, 205, 57, 24, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 209, 128, 84, 32, 13, 72, 5, 154, 3, 154, 5, 50, 1, 108, 0, 19, 192, 6, 24, 4, 27, 6, 187, 7, 124, 62, 183, 188, 11, 116, 12, 112, 34, 13, 19, 192, 6, 48, 1, 108, 128, 107, 144, 84, 70, 9, 32, 1, 36, 128, 4, 160, 1, 104, 0, 46, 128, 11, 184, 203, 28, 192, 32, 232, 188, 65, 208, 45, 31, 13, 176, 11, 56, 141, 123, 238, 2, 220, 3, 156, 198, 77, 175, 66, 249, 128, 96, 15, 96, 31, 120, 30, 247, 125, 48, 164, 145, 1, 103, 196, 255, 198, 175, 137, 146, 1, 217, 241, 255, 99, 28, 196, 12, 30, 107, 0, 111, 255, 143, 163, 154, 78, 10, 28, 23, 254, 174, 138, 255, 28, 55, 140, 203, 44, 11, 74, 199, 126, 94, 198, 186, 254, 131, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 247, 231, 95, 23, 190, 217, 98, 181, 249, 103, 109, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "mobile" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UpdatedAt", "UserId" },
                values: new object[] { 1, 1, new DateTime(2020, 8, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UpdatedAt", "UserId" },
                values: new object[] { 2, 2, new DateTime(2020, 8, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
