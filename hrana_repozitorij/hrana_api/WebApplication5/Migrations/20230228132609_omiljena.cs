using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class omiljena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OmiljenaStavka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    MeniStavkaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OmiljenaStavka", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OmiljenaStavka_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OmiljenaStavka_Meni_MeniStavkaID",
                        column: x => x.MeniStavkaID,
                        principalTable: "Meni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OmiljenaStavka_KorisnikID",
                table: "OmiljenaStavka",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_OmiljenaStavka_MeniStavkaID",
                table: "OmiljenaStavka",
                column: "MeniStavkaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OmiljenaStavka");
        }
    }
}
