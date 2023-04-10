using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class korisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineNarudzba_DostavaNalog_DostavaNalogId",
                table: "OnlineNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineNarudzba_Korisnik_OnlineGostId",
                table: "OnlineNarudzba");

            migrationBuilder.DropIndex(
                name: "IX_OnlineNarudzba_DostavaNalogId",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "NazivJela",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "OnlineNarudzba");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OnlineNarudzba",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "OnlineGostId",
                table: "OnlineNarudzba",
                newName: "KorisnikID");

            migrationBuilder.RenameColumn(
                name: "DostavaNalogId",
                table: "OnlineNarudzba",
                newName: "BrojStavki");

            migrationBuilder.RenameColumn(
                name: "DatumNarudzbe",
                table: "OnlineNarudzba",
                newName: "DatumNarucivanja");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineNarudzba_OnlineGostId",
                table: "OnlineNarudzba",
                newName: "IX_OnlineNarudzba_KorisnikID");

            migrationBuilder.AddColumn<bool>(
                name: "Omiljeno",
                table: "OnlineNarudzba",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StatusNarudzbeID",
                table: "OnlineNarudzba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UposlenikID",
                table: "OnlineNarudzba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Zakljucena",
                table: "OnlineNarudzba",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StatusNarudzbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusNarudzbe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineNarudzba_StatusNarudzbeID",
                table: "OnlineNarudzba",
                column: "StatusNarudzbeID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineNarudzba_UposlenikID",
                table: "OnlineNarudzba",
                column: "UposlenikID");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineNarudzba_Korisnik_KorisnikID",
                table: "OnlineNarudzba",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineNarudzba_StatusNarudzbe_StatusNarudzbeID",
                table: "OnlineNarudzba",
                column: "StatusNarudzbeID",
                principalTable: "StatusNarudzbe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineNarudzba_Uposlenik_UposlenikID",
                table: "OnlineNarudzba",
                column: "UposlenikID",
                principalTable: "Uposlenik",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineNarudzba_Korisnik_KorisnikID",
                table: "OnlineNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineNarudzba_StatusNarudzbe_StatusNarudzbeID",
                table: "OnlineNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineNarudzba_Uposlenik_UposlenikID",
                table: "OnlineNarudzba");

            migrationBuilder.DropTable(
                name: "StatusNarudzbe");

            migrationBuilder.DropIndex(
                name: "IX_OnlineNarudzba_StatusNarudzbeID",
                table: "OnlineNarudzba");

            migrationBuilder.DropIndex(
                name: "IX_OnlineNarudzba_UposlenikID",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "Omiljeno",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "StatusNarudzbeID",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "UposlenikID",
                table: "OnlineNarudzba");

            migrationBuilder.DropColumn(
                name: "Zakljucena",
                table: "OnlineNarudzba");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OnlineNarudzba",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "KorisnikID",
                table: "OnlineNarudzba",
                newName: "OnlineGostId");

            migrationBuilder.RenameColumn(
                name: "DatumNarucivanja",
                table: "OnlineNarudzba",
                newName: "DatumNarudzbe");

            migrationBuilder.RenameColumn(
                name: "BrojStavki",
                table: "OnlineNarudzba",
                newName: "DostavaNalogId");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineNarudzba_KorisnikID",
                table: "OnlineNarudzba",
                newName: "IX_OnlineNarudzba_OnlineGostId");

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "OnlineNarudzba",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "OnlineNarudzba",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NazivJela",
                table: "OnlineNarudzba",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "OnlineNarudzba",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "OnlineNarudzba",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineNarudzba_DostavaNalogId",
                table: "OnlineNarudzba",
                column: "DostavaNalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineNarudzba_DostavaNalog_DostavaNalogId",
                table: "OnlineNarudzba",
                column: "DostavaNalogId",
                principalTable: "DostavaNalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineNarudzba_Korisnik_OnlineGostId",
                table: "OnlineNarudzba",
                column: "OnlineGostId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
