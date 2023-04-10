﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Data;

#nullable disable

namespace WebApplication5.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230116083944_pokusaj")]
    partial class pokusaj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication5.EntityModels.AutentifikacijaToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IpAdresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("Vrijednost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.LogKretanjePoSistemu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ExceptionMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAdresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Vrijeme")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isException")
                        .HasColumnType("bit");

                    b.Property<int>("korisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("korisnikId");

                    b.ToTable("LogKretanjePoSistemu");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.Opstina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Opstina");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.Restoran", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpstinaId")
                        .HasColumnType("int");

                    b.Property<string>("RadnoVrijemeRedovno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RadnoVrijemeVikend")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OpstinaId");

                    b.ToTable("Restoran");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrojOsoba")
                        .HasColumnType("int");

                    b.Property<int>("BrojStolova")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<bool>("Obavljena")
                        .HasColumnType("bit");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VrijemeRezrvacije")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("WebApplication5.Models.DnevnaPonuda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cijena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DnevnaPonuda");
                });

            modelBuilder.Entity("WebApplication5.Models.DostavaNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatumIsporuke")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestoranId")
                        .HasColumnType("int");

                    b.Property<int>("UposlenikId")
                        .HasColumnType("int");

                    b.Property<int>("VoziloZaDostavuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestoranId");

                    b.HasIndex("UposlenikId");

                    b.HasIndex("VoziloZaDostavuId");

                    b.ToTable("DostavaNalog");
                });

            modelBuilder.Entity("WebApplication5.Models.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("WebApplication5.Models.Meni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Cijena")
                        .HasColumnType("real");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<string>("LinkZaSliku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("StanjeNaSkladistu")
                        .HasColumnType("real");

                    b.Property<string>("ZaDostavu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Meni");
                });

            modelBuilder.Entity("WebApplication5.Models.NarudzbaStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DnevnaPonudaId")
                        .HasColumnType("int");

                    b.Property<string>("Kolicina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeniId")
                        .HasColumnType("int");

                    b.Property<int>("OnlineNarudzbaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DnevnaPonudaId");

                    b.HasIndex("MeniId");

                    b.HasIndex("OnlineNarudzbaId");

                    b.ToTable("NarudzbaStavka");
                });

            modelBuilder.Entity("WebApplication5.Models.Notifikacije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OnlineGostId")
                        .HasColumnType("int");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OnlineGostId");

                    b.ToTable("Notifikacije");
                });

            modelBuilder.Entity("WebApplication5.Models.Obavijesti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Obavijesti");
                });

            modelBuilder.Entity("WebApplication5.Models.OnlineNarudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Cijena")
                        .HasColumnType("real");

                    b.Property<DateTime>("DatumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<int>("DostavaNalogId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivJela")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OnlineGostId")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DostavaNalogId");

                    b.HasIndex("OnlineGostId");

                    b.ToTable("OnlineNarudzba");
                });

            modelBuilder.Entity("WebApplication5.Models.PonudaStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DnevnaPonudaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("DostupnaKolicina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeniId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DnevnaPonudaId");

                    b.HasIndex("MeniId");

                    b.ToTable("PonudaStavka");
                });

            modelBuilder.Entity("WebApplication5.Models.StavkaUlaza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Kolicina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeniId")
                        .HasColumnType("int");

                    b.Property<int>("UlazUSkaldisteId")
                        .HasColumnType("int");

                    b.Property<int>("UlazUSkladisteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeniId");

                    b.HasIndex("UlazUSkaldisteId");

                    b.ToTable("StavkaUlaza");
                });

            modelBuilder.Entity("WebApplication5.Models.UlazUSkladiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Cijena")
                        .HasColumnType("real");

                    b.Property<DateTime>("DatumPrijema")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImeDobavljaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("KolicinaUlaza")
                        .HasColumnType("real");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UposlenikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UposlenikId");

                    b.ToTable("UlazUSkladiste");
                });

            modelBuilder.Entity("WebApplication5.Models.UposlenikObavijesti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ObavijestiId")
                        .HasColumnType("int");

                    b.Property<int>("UposlenikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObavijestiId");

                    b.HasIndex("UposlenikId");

                    b.ToTable("UposlenikObavijesti");
                });

            modelBuilder.Entity("WebApplication5.Models.VoziloZaDostavu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VoziloZaDostavu");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.Administrator", b =>
                {
                    b.HasBaseType("WebApplication5.EntityModels.KorisnickiNalog");

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("WebApplication5.Models.Korisnik", b =>
                {
                    b.HasBaseType("WebApplication5.EntityModels.KorisnickiNalog");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpstinaId")
                        .HasColumnType("int");

                    b.HasIndex("OpstinaId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("WebApplication5.Models.Uposlenik", b =>
                {
                    b.HasBaseType("WebApplication5.EntityModels.KorisnickiNalog");

                    b.Property<int>("AktivneNarudzbe")
                        .HasColumnType("int");

                    b.Property<int>("ObavljeneNarudzbe")
                        .HasColumnType("int");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Uposlenik");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.AutentifikacijaToken", b =>
                {
                    b.HasOne("WebApplication5.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KorisnickiNalog");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.LogKretanjePoSistemu", b =>
                {
                    b.HasOne("WebApplication5.EntityModels.KorisnickiNalog", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.Restoran", b =>
                {
                    b.HasOne("WebApplication5.EntityModels.Opstina", "Opstina")
                        .WithMany()
                        .HasForeignKey("OpstinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Opstina");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.Rezervacija", b =>
                {
                    b.HasOne("WebApplication5.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorija");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("WebApplication5.Models.DostavaNalog", b =>
                {
                    b.HasOne("WebApplication5.EntityModels.Restoran", "Restoran")
                        .WithMany()
                        .HasForeignKey("RestoranId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.Uposlenik", "Uposlenik")
                        .WithMany()
                        .HasForeignKey("UposlenikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.VoziloZaDostavu", "VoziloZaDostavu")
                        .WithMany()
                        .HasForeignKey("VoziloZaDostavuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restoran");

                    b.Navigation("Uposlenik");

                    b.Navigation("VoziloZaDostavu");
                });

            modelBuilder.Entity("WebApplication5.Models.Meni", b =>
                {
                    b.HasOne("WebApplication5.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorija");
                });

            modelBuilder.Entity("WebApplication5.Models.NarudzbaStavka", b =>
                {
                    b.HasOne("WebApplication5.Models.DnevnaPonuda", "DnevnaPonuda")
                        .WithMany()
                        .HasForeignKey("DnevnaPonudaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.Meni", "Meni")
                        .WithMany()
                        .HasForeignKey("MeniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.OnlineNarudzba", "OnlineNarudzba")
                        .WithMany()
                        .HasForeignKey("OnlineNarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DnevnaPonuda");

                    b.Navigation("Meni");

                    b.Navigation("OnlineNarudzba");
                });

            modelBuilder.Entity("WebApplication5.Models.Notifikacije", b =>
                {
                    b.HasOne("WebApplication5.Models.Korisnik", "OnlineGost")
                        .WithMany()
                        .HasForeignKey("OnlineGostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OnlineGost");
                });

            modelBuilder.Entity("WebApplication5.Models.OnlineNarudzba", b =>
                {
                    b.HasOne("WebApplication5.Models.DostavaNalog", "DostavaNalog")
                        .WithMany()
                        .HasForeignKey("DostavaNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.Korisnik", "OnlineGost")
                        .WithMany()
                        .HasForeignKey("OnlineGostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DostavaNalog");

                    b.Navigation("OnlineGost");
                });

            modelBuilder.Entity("WebApplication5.Models.PonudaStavka", b =>
                {
                    b.HasOne("WebApplication5.Models.DnevnaPonuda", "DnevnaPonuda")
                        .WithMany()
                        .HasForeignKey("DnevnaPonudaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.Meni", "Meni")
                        .WithMany()
                        .HasForeignKey("MeniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DnevnaPonuda");

                    b.Navigation("Meni");
                });

            modelBuilder.Entity("WebApplication5.Models.StavkaUlaza", b =>
                {
                    b.HasOne("WebApplication5.Models.Meni", "Meni")
                        .WithMany()
                        .HasForeignKey("MeniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.UlazUSkladiste", "UlazUSkladiste")
                        .WithMany()
                        .HasForeignKey("UlazUSkaldisteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meni");

                    b.Navigation("UlazUSkladiste");
                });

            modelBuilder.Entity("WebApplication5.Models.UlazUSkladiste", b =>
                {
                    b.HasOne("WebApplication5.Models.Uposlenik", "Uposlenik")
                        .WithMany()
                        .HasForeignKey("UposlenikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uposlenik");
                });

            modelBuilder.Entity("WebApplication5.Models.UposlenikObavijesti", b =>
                {
                    b.HasOne("WebApplication5.Models.Obavijesti", "Obavijesti")
                        .WithMany("Uposlenik")
                        .HasForeignKey("ObavijestiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.Uposlenik", "Uposlenik")
                        .WithMany()
                        .HasForeignKey("UposlenikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Obavijesti");

                    b.Navigation("Uposlenik");
                });

            modelBuilder.Entity("WebApplication5.EntityModels.Administrator", b =>
                {
                    b.HasOne("WebApplication5.EntityModels.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("WebApplication5.EntityModels.Administrator", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication5.Models.Korisnik", b =>
                {
                    b.HasOne("WebApplication5.EntityModels.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("WebApplication5.Models.Korisnik", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.EntityModels.Opstina", "Opstina")
                        .WithMany()
                        .HasForeignKey("OpstinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Opstina");
                });

            modelBuilder.Entity("WebApplication5.Models.Uposlenik", b =>
                {
                    b.HasOne("WebApplication5.EntityModels.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("WebApplication5.Models.Uposlenik", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication5.Models.Obavijesti", b =>
                {
                    b.Navigation("Uposlenik");
                });
#pragma warning restore 612, 618
        }
    }
}
