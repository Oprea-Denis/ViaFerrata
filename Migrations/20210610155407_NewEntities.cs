using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViaFerrata.Migrations
{
    public partial class NewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cerinte",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Echipament = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experienta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varsta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cerinte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dificultate",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificultate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Experienta",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varsta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraseeParcurse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dificultate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experienta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inchiriere",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inchiriere", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cerinte");

            migrationBuilder.DropTable(
                name: "Dificultate");

            migrationBuilder.DropTable(
                name: "Experienta");

            migrationBuilder.DropTable(
                name: "Inchiriere");
        }
    }
}
