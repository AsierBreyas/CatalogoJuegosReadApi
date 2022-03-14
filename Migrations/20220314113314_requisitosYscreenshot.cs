using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogoJuegosApi.Migrations
{
    public partial class requisitosYscreenshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogoJuegos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    game_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plataform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    freetogame_profile_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    screenshots = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    os = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    processor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    memory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    graphics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoJuegos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoJuegos");
        }
    }
}
