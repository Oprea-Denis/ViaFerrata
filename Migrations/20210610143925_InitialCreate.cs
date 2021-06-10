using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViaFerrata.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Traseu",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeSiLocatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dificultate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taxa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traseu", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Traseu");
        }
    }
}
