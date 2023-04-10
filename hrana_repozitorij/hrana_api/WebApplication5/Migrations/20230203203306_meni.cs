using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class meni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaId",
                table: "Meni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meni_KategorijaId",
                table: "Meni",
                column: "KategorijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meni_Kategorija_KategorijaId",
                table: "Meni",
                column: "KategorijaId",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meni_Kategorija_KategorijaId",
                table: "Meni");

            migrationBuilder.DropIndex(
                name: "IX_Meni_KategorijaId",
                table: "Meni");

            migrationBuilder.DropColumn(
                name: "KategorijaId",
                table: "Meni");
        }
    }
}
