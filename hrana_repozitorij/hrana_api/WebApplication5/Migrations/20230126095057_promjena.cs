using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class promjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Meni_MeniId",
                table: "NarudzbaStavka");

            migrationBuilder.RenameColumn(
                name: "MeniId",
                table: "NarudzbaStavka",
                newName: "MeniStavkaId");

            migrationBuilder.RenameIndex(
                name: "IX_NarudzbaStavka_MeniId",
                table: "NarudzbaStavka",
                newName: "IX_NarudzbaStavka_MeniStavkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Meni_MeniStavkaId",
                table: "NarudzbaStavka",
                column: "MeniStavkaId",
                principalTable: "Meni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Meni_MeniStavkaId",
                table: "NarudzbaStavka");

            migrationBuilder.RenameColumn(
                name: "MeniStavkaId",
                table: "NarudzbaStavka",
                newName: "MeniId");

            migrationBuilder.RenameIndex(
                name: "IX_NarudzbaStavka_MeniStavkaId",
                table: "NarudzbaStavka",
                newName: "IX_NarudzbaStavka_MeniId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Meni_MeniId",
                table: "NarudzbaStavka",
                column: "MeniId",
                principalTable: "Meni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
