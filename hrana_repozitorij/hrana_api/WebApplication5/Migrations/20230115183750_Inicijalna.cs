using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class Inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DnevnaPonuda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnevnaPonuda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obavijesti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijesti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoziloZaDostavu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoziloZaDostavu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    LinkZaSliku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StanjeNaSkladistu = table.Column<float>(type: "real", nullable: false),
                    ZaDostavu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meni_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogKretanjePoSistemu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    QueryPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isException = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogKretanjePoSistemu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogKretanjePoSistemu_KorisnickiNalog_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObavljeneNarudzbe = table.Column<int>(type: "int", nullable: false),
                    AktivneNarudzbe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uposlenik_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpstinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Korisnik_Opstina_OpstinaId",
                        column: x => x.OpstinaId,
                        principalTable: "Opstina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restoran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpstinaId = table.Column<int>(type: "int", nullable: false),
                    RadnoVrijemeRedovno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadnoVrijemeVikend = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoran", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restoran_Opstina_OpstinaId",
                        column: x => x.OpstinaId,
                        principalTable: "Opstina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PonudaStavka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DostupnaKolicina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeniId = table.Column<int>(type: "int", nullable: false),
                    DnevnaPonudaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonudaStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PonudaStavka_DnevnaPonuda_DnevnaPonudaId",
                        column: x => x.DnevnaPonudaId,
                        principalTable: "DnevnaPonuda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PonudaStavka_Meni_MeniId",
                        column: x => x.MeniId,
                        principalTable: "Meni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UlazUSkladiste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    KolicinaUlaza = table.Column<float>(type: "real", nullable: false),
                    ImeDobavljaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPrijema = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UposlenikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlazUSkladiste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlazUSkladiste_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UposlenikObavijesti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UposlenikId = table.Column<int>(type: "int", nullable: false),
                    ObavijestiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UposlenikObavijesti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UposlenikObavijesti_Obavijesti_ObavijestiId",
                        column: x => x.ObavijestiId,
                        principalTable: "Obavijesti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UposlenikObavijesti_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnlineGostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifikacije_Korisnik_OnlineGostId",
                        column: x => x.OnlineGostId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojOsoba = table.Column<int>(type: "int", nullable: false),
                    BrojStolova = table.Column<int>(type: "int", nullable: false),
                    Obavljena = table.Column<bool>(type: "bit", nullable: false),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VrijemeRezrvacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DostavaNalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIsporuke = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestoranId = table.Column<int>(type: "int", nullable: false),
                    UposlenikId = table.Column<int>(type: "int", nullable: false),
                    VoziloZaDostavuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DostavaNalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DostavaNalog_Restoran_RestoranId",
                        column: x => x.RestoranId,
                        principalTable: "Restoran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DostavaNalog_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DostavaNalog_VoziloZaDostavu_VoziloZaDostavuId",
                        column: x => x.VoziloZaDostavuId,
                        principalTable: "VoziloZaDostavu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkaUlaza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlazUSkaldisteId = table.Column<int>(type: "int", nullable: false),
                    UlazUSkladisteId = table.Column<int>(type: "int", nullable: false),
                    MeniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaUlaza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkaUlaza_Meni_MeniId",
                        column: x => x.MeniId,
                        principalTable: "Meni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkaUlaza_UlazUSkladiste_UlazUSkaldisteId",
                        column: x => x.UlazUSkaldisteId,
                        principalTable: "UlazUSkladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineNarudzba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivJela = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnlineGostId = table.Column<int>(type: "int", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DostavaNalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineNarudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineNarudzba_DostavaNalog_DostavaNalogId",
                        column: x => x.DostavaNalogId,
                        principalTable: "DostavaNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineNarudzba_Korisnik_OnlineGostId",
                        column: x => x.OnlineGostId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeniId = table.Column<int>(type: "int", nullable: false),
                    DnevnaPonudaId = table.Column<int>(type: "int", nullable: false),
                    OnlineNarudzbaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_DnevnaPonuda_DnevnaPonudaId",
                        column: x => x.DnevnaPonudaId,
                        principalTable: "DnevnaPonuda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Meni_MeniId",
                        column: x => x.MeniId,
                        principalTable: "Meni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_OnlineNarudzba_OnlineNarudzbaId",
                        column: x => x.OnlineNarudzbaId,
                        principalTable: "OnlineNarudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_DostavaNalog_RestoranId",
                table: "DostavaNalog",
                column: "RestoranId");

            migrationBuilder.CreateIndex(
                name: "IX_DostavaNalog_UposlenikId",
                table: "DostavaNalog",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_DostavaNalog_VoziloZaDostavuId",
                table: "DostavaNalog",
                column: "VoziloZaDostavuId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_OpstinaId",
                table: "Korisnik",
                column: "OpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_LogKretanjePoSistemu_korisnikId",
                table: "LogKretanjePoSistemu",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Meni_KategorijaId",
                table: "Meni",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_DnevnaPonudaId",
                table: "NarudzbaStavka",
                column: "DnevnaPonudaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_MeniId",
                table: "NarudzbaStavka",
                column: "MeniId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_OnlineNarudzbaId",
                table: "NarudzbaStavka",
                column: "OnlineNarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacije_OnlineGostId",
                table: "Notifikacije",
                column: "OnlineGostId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineNarudzba_DostavaNalogId",
                table: "OnlineNarudzba",
                column: "DostavaNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineNarudzba_OnlineGostId",
                table: "OnlineNarudzba",
                column: "OnlineGostId");

            migrationBuilder.CreateIndex(
                name: "IX_PonudaStavka_DnevnaPonudaId",
                table: "PonudaStavka",
                column: "DnevnaPonudaId");

            migrationBuilder.CreateIndex(
                name: "IX_PonudaStavka_MeniId",
                table: "PonudaStavka",
                column: "MeniId");

            migrationBuilder.CreateIndex(
                name: "IX_Restoran_OpstinaId",
                table: "Restoran",
                column: "OpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KategorijaId",
                table: "Rezervacija",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikId",
                table: "Rezervacija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaUlaza_MeniId",
                table: "StavkaUlaza",
                column: "MeniId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaUlaza_UlazUSkaldisteId",
                table: "StavkaUlaza",
                column: "UlazUSkaldisteId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazUSkladiste_UposlenikId",
                table: "UlazUSkladiste",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikObavijesti_ObavijestiId",
                table: "UposlenikObavijesti",
                column: "ObavijestiId");

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikObavijesti_UposlenikId",
                table: "UposlenikObavijesti",
                column: "UposlenikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "LogKretanjePoSistemu");

            migrationBuilder.DropTable(
                name: "NarudzbaStavka");

            migrationBuilder.DropTable(
                name: "Notifikacije");

            migrationBuilder.DropTable(
                name: "PonudaStavka");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "StavkaUlaza");

            migrationBuilder.DropTable(
                name: "UposlenikObavijesti");

            migrationBuilder.DropTable(
                name: "OnlineNarudzba");

            migrationBuilder.DropTable(
                name: "DnevnaPonuda");

            migrationBuilder.DropTable(
                name: "Meni");

            migrationBuilder.DropTable(
                name: "UlazUSkladiste");

            migrationBuilder.DropTable(
                name: "Obavijesti");

            migrationBuilder.DropTable(
                name: "DostavaNalog");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Restoran");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "VoziloZaDostavu");

            migrationBuilder.DropTable(
                name: "Opstina");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");
        }
    }
}
