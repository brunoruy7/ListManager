using Microsoft.EntityFrameworkCore.Migrations;

namespace ListManager.Data.Migrations
{
    public partial class AddedForingKeyUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Lista");

            migrationBuilder.AddColumn<string>(
                name: "UserIDId",
                table: "Lista",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lista_UserIDId",
                table: "Lista",
                column: "UserIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lista_AspNetUsers_UserIDId",
                table: "Lista",
                column: "UserIDId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lista_AspNetUsers_UserIDId",
                table: "Lista");

            migrationBuilder.DropIndex(
                name: "IX_Lista_UserIDId",
                table: "Lista");

            migrationBuilder.DropColumn(
                name: "UserIDId",
                table: "Lista");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Lista",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
