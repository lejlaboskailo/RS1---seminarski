using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.EntityModels;
using WebApplication5.Helper.AutentifikacijaAutorizacija;
using WebApplication5.KorisnikModul.ViewModels;
using WebApplication5.Models;
using WebApplication5.ModulKorisnickiNalog.ViewModels;

namespace WebApplication5.ModulKorisnickiNalog.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class KorisnickiNalogController : Controller
  {
    private ApplicationDbContext _dbContext;

    public KorisnickiNalogController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult Get()
    {
      if (!HttpContext.GetLoginInfo().isLogiran)
        return BadRequest("nije logiran");

      KorisnikGetVM korisnikGetVM = new KorisnikGetVM();
      KorisnickiNalog defaultniNalog = new KorisnickiNalog();

      if (HttpContext.GetLoginInfo().isPermsijaKorisnik)
      {
        Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;
        if (korisnik == null)
          return BadRequest("Nepostojeci korisnik");

        defaultniNalog = korisnik;
        korisnikGetVM.BrojTelefona = korisnik.BrojTelefona;
        korisnikGetVM.AdresaStanovanja = korisnik.Adresa;
        korisnikGetVM.OpstinaId = korisnik.OpstinaId;
      }
      /*else if (HttpContext.GetLoginInfo().isPermsijaAdministrator)
      {
        Administrator admin = HttpContext.GetLoginInfo().korisnickiNalog.Administrator;
        if (admin == null)
          return BadRequest("Nepostojeci administrator");
        defaultniNalog = admin;
      }
            else if (HttpContext.GetLoginInfo().isPermisijaUposlenik)
            {
                Uposlenik uposlenik = HttpContext.GetLoginInfo().korisnickiNalog.Uposlenik;
                if (uposlenik == null)
                    return BadRequest("Nepostojeci zaposlenik");
                defaultniNalog = uposlenik;
                korisnikGetVM.Slika = uposlenik.Slika;
            }
      */
            korisnikGetVM.Ime = defaultniNalog.Ime;
      korisnikGetVM.Prezime = defaultniNalog.Prezime;
      korisnikGetVM.Email = defaultniNalog.Email;
      korisnikGetVM.KorisnickoIme = defaultniNalog.KorisnickoIme;
      korisnikGetVM.Lozinka = defaultniNalog.Lozinka;

      return Ok(korisnikGetVM);
    }
    [HttpPost]
    public IActionResult UpdateAdmin([FromBody] AdminUpdateVM adminUpdateVM)
    {


      if (!HttpContext.GetLoginInfo().isPermsijaAdministrator)
        return BadRequest("Nije logiran");

      Administrator admin = HttpContext.GetLoginInfo().korisnickiNalog.Administrator;
      if (admin == null)
        return BadRequest("Nepostojeci administrator");

      admin.Ime = adminUpdateVM.ime;
      admin.Prezime = adminUpdateVM.prezime;
      admin.Email = adminUpdateVM.email;
      admin.KorisnickoIme = adminUpdateVM.korisnickoIme;
      admin.Lozinka = adminUpdateVM.lozinka;
      admin.DatumKreiranja = DateTime.Now;

      _dbContext.SaveChanges();
      return Ok(admin);

    }
  }
}
