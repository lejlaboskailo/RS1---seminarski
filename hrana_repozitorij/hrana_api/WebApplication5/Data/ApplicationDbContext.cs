using Microsoft.EntityFrameworkCore;
using WebApplication5.EntityModels;
using WebApplication5.Models;

namespace WebApplication5.Data
{
  public class ApplicationDbContext:DbContext
    {
        public DbSet<DnevnaPonuda> DnevnaPonuda { get; set; }
        public DbSet<DostavaNalog> DostavaNalog { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<MeniStavka> Meni { get; set; }
        public DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        public DbSet<Notifikacije> Notifikacije { get; set; }
        public DbSet<Obavijesti> Obavijesti { get; set; }
        public DbSet<Korisnik> OnlineGost { get; set; }
        public DbSet<OnlineNarudzba> OnlineNarudzba { get; set; }
        public DbSet<PonudaStavka> PonudaStavka { get; set; }
        public DbSet<Restoran> Restoran { get; set; }
        public DbSet<StavkaUlaza> StavkaUlaza { get; set; }
        public DbSet<UlazUSkladiste> UlazUSkladiste { get; set; }
        public DbSet<Uposlenik> Uposlenik { get; set; }
        public DbSet<UposlenikObavijesti> UposlenikObavijesti { get; set; }
        public DbSet<VoziloZaDostavu> VoziloZaDostavu { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<StatusNarudzbe> StatusNarudzbe { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemu { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
      
        public DbSet<OmiljenaStavka> OmiljenaStavka { get; set; }
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

      
    }
}
