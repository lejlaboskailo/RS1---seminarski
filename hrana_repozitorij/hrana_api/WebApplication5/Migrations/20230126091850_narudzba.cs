using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class narudzba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meni_Kategorija_KategorijaId",
                table: "Meni");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_DnevnaPonuda_DnevnaPonudaId",
                table: "NarudzbaStavka");

            migrationBuilder.DropIndex(
                name: "IX_NarudzbaStavka_DnevnaPonudaId",
                table: "NarudzbaStavka");

            migrationBuilder.DropIndex(
                name: "IX_Meni_KategorijaId",
                table: "Meni");

            migrationBuilder.DropColumn(
                name: "Omiljeno",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "DnevnaPonudaId",
                table: "NarudzbaStavka");

            migrationBuilder.DropColumn(
                name: "KategorijaId",
                table: "Meni");

            migrationBuilder.DropColumn(
                name: "LinkZaSliku",
                table: "Meni");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Meni",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ZaDostavu",
                table: "Meni",
                newName: "Slika");

            migrationBuilder.RenameColumn(
                name: "StanjeNaSkladistu",
                table: "Meni",
                newName: "SnizenaCijena");

            migrationBuilder.AlterColumn<int>(
                name: "Kolicina",
                table: "NarudzbaStavka",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<float>(
                name: "Iznos",
                table: "NarudzbaStavka",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Izdvojeno",
                table: "Meni",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Ocjena",
                table: "Meni",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iznos",
                table: "NarudzbaStavka");

            migrationBuilder.DropColumn(
                name: "Izdvojeno",
                table: "Meni");

            migrationBuilder.DropColumn(
                name: "Ocjena",
                table: "Meni");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Meni",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SnizenaCijena",
                table: "Meni",
                newName: "StanjeNaSkladistu");

            migrationBuilder.RenameColumn(
                name: "Slika",
                table: "Meni",
                newName: "ZaDostavu");

            migrationBuilder.AddColumn<bool>(
                name: "Omiljeno",
                table: "OnlineNarudzba",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Kolicina",
                table: "NarudzbaStavka",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DnevnaPonudaId",
                table: "NarudzbaStavka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KategorijaId",
                table: "Meni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LinkZaSliku",
                table: "Meni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_DnevnaPonudaId",
                table: "NarudzbaStavka",
                column: "DnevnaPonudaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_DnevnaPonuda_DnevnaPonudaId",
                table: "NarudzbaStavka",
                column: "DnevnaPonudaId",
                principalTable: "DnevnaPonuda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
