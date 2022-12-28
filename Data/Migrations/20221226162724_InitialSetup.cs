using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListManager.Data.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Completed = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    prazo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Afazeres",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Completed = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Detalhes = table.Column<string>(nullable: true),
                    prazo = table.Column<DateTime>(nullable: false),
                    ListaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afazeres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Afazeres_Lista_ListaID",
                        column: x => x.ListaID,
                        principalTable: "Lista",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afazeres_ListaID",
                table: "Afazeres",
                column: "ListaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afazeres");

            migrationBuilder.DropTable(
                name: "Lista");
        }
    }
}
