﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WriteIT.Migrations
{
    public partial class AddSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BestCharacter = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MyRate = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
