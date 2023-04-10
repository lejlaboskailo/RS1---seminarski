using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Helper.AutentifikacijaAutorizacija;
using WebApplication5.Models;
using WebApplication5.ModulNarudzba.ViewModels;

namespace WebApplication5.ModulNarudzba.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class NarudzbaController:ControllerBase
  {
    private ApplicationDbContext _dbContext;
    public NarudzbaController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    [HttpPost]
    public IActionResult AddStavka([FromBody]NarudzbaAddStavkaVM stavkaAddVM)
    {
      if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
        return BadRequest("nije logiran");
      Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;
      if (korisnik == null)
        return BadRequest("nepostojeci korisnik");

      OnlineNarudzba narudzba=_dbContext.OnlineNarudzba.Where(n=>n.KorisnikID==korisnik.Id&&n.Zakljucena==false).SingleOrDefault();
      if(narudzba==null)
      {
        narudzba = new OnlineNarudzba()
        {
          DatumNarucivanja = DateTime.Now,
          Zakljucena = false,
          Korisnik = korisnik,
          BrojStavki = 0,
          Cijena = 0,
        };
        _dbContext.OnlineNarudzba.Add(narudzba);
        _dbContext.SaveChanges();
      }
      MeniStavka meniStavka = _dbContext.Meni.Find(stavkaAddVM.meniStavkaId);
      NarudzbaStavka stavkaNarudzbe = new NarudzbaStavka()
      {
        Kolicina = 1,
        MeniStavkaId = stavkaAddVM.meniStavkaId,
        OnlineNarudzbaId = narudzba.ID,
        Iznos = meniStavka.Izdvojeno ? meniStavka.SnizenaCijena : meniStavka.Cijena
      };
      _dbContext.NarudzbaStavka.Add(stavkaNarudzbe);
      narudzba.BrojStavki++;
      narudzba.Cijena += stavkaNarudzbe.Iznos;
      _dbContext.SaveChanges();

      return Ok(narudzba.BrojStavki);
    }
    [HttpGet]
    public IActionResult GetNarudzba()
    {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");
            int id = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik.Id;
      OnlineNarudzba narudzba=_dbContext.OnlineNarudzba.Where(n=>n.KorisnikID== id&&n.Zakljucena==false).FirstOrDefault();
      if (narudzba == null)
      {
        narudzba = new OnlineNarudzba()
        {
          DatumNarucivanja = DateTime.Now,
          Zakljucena = false,
          KorisnikID = id,
          BrojStavki = 0,
          Cijena = 0,
        };
        _dbContext.OnlineNarudzba.Add(narudzba);
        _dbContext.SaveChanges();
      }
      NarudzbaGetNarudzbaVM getNarudzbaVM = new NarudzbaGetNarudzbaVM()
      {
        id = narudzba.ID,
        cijena = narudzba.Cijena,
        stavke = _dbContext.NarudzbaStavka.Where(sn => sn.OnlineNarudzbaId == narudzba.ID).Select(sn => new NarudzbaGetNarudzbaVM.Stavka()
        {
          id = sn.Id,
          naziv = sn.MeniStavka.Naziv,
          opis = sn.MeniStavka.Opis,
          cijena = sn.MeniStavka.Cijena,
          slika = sn.MeniStavka.Slika,
          izdvojeno = sn.MeniStavka.Izdvojeno,
          snizenaCijena = sn.MeniStavka.SnizenaCijena,
          ocjena = sn.MeniStavka.Ocjena,
          kolicina = sn.Kolicina
        }).ToList(),
      };
      return Ok(getNarudzbaVM);
    }
    [HttpGet]
    public IActionResult GetBrojStavki()
    {
      if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
        return BadRequest("nije logiran");

      int id = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik.Id;

      Korisnik korisnik = _dbContext.Korisnik.Find(id);
      if (korisnik == null) return Ok(0);

      OnlineNarudzba narudzba = _dbContext.OnlineNarudzba.Where(n => n.KorisnikID == id && n.Zakljucena == false).FirstOrDefault();
      if (narudzba == null) return Ok(0);

      return Ok(narudzba.BrojStavki);
    }
        [HttpGet("{id}")]
        public IActionResult UkloniStavku(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            NarudzbaStavka stavkaNarudzbe = _dbContext.NarudzbaStavka.Where(sn => sn.Id == id).FirstOrDefault();

            OnlineNarudzba narudzba = _dbContext.OnlineNarudzba.Where(n => n.ID == stavkaNarudzbe.OnlineNarudzbaId).SingleOrDefault();
            if (narudzba == null)
                return BadRequest("Nepostojeca narudzba");

            _dbContext.NarudzbaStavka.Remove(stavkaNarudzbe);
            narudzba.Cijena -= stavkaNarudzbe.Iznos;
            narudzba.BrojStavki -= stavkaNarudzbe.Kolicina;
            _dbContext.SaveChanges();

            NarudzbaGetNarudzbaVM getNarudzbaVM = new NarudzbaGetNarudzbaVM()
            {
                id = narudzba.ID,
                cijena = narudzba.Cijena,
                stavke = _dbContext.NarudzbaStavka.Where(sn => sn.OnlineNarudzbaId == narudzba.ID).Select(sn => new NarudzbaGetNarudzbaVM.Stavka()
                {
                    id = sn.Id,
                    naziv = sn.MeniStavka.Naziv,
                    opis = sn.MeniStavka.Opis,
                    cijena = sn.MeniStavka.Cijena,
                    slika = sn.MeniStavka.Slika,
                    izdvojeno = sn.MeniStavka.Izdvojeno,
                    snizenaCijena = sn.MeniStavka.SnizenaCijena,
                    ocjena = sn.MeniStavka.Ocjena,
                    kolicina = sn.Kolicina
                }).ToList(),
            };

            return Ok(getNarudzbaVM);
        }
        [HttpPost]
        public IActionResult UpdateKolicina(NarudzbaUpdateKolicinaVM narudzbaUpdateKolicinaVM)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            NarudzbaStavka stavkaNarudzbe = _dbContext.NarudzbaStavka.Include(sn => sn.MeniStavka)
                                            .Where(sn => sn.Id == narudzbaUpdateKolicinaVM.Id).SingleOrDefault();
            if (stavkaNarudzbe == null)
                return BadRequest("Nepostojeca stavka narudzbe");

            OnlineNarudzba narudzba = _dbContext.OnlineNarudzba.Find(stavkaNarudzbe.OnlineNarudzbaId);
            narudzba.Cijena -= stavkaNarudzbe.Iznos;
            narudzba.BrojStavki -= stavkaNarudzbe.Kolicina;

            stavkaNarudzbe.Kolicina = narudzbaUpdateKolicinaVM.Kolicina;

            if (!stavkaNarudzbe.MeniStavka.Izdvojeno)
                stavkaNarudzbe.Iznos = stavkaNarudzbe.MeniStavka.Cijena * narudzbaUpdateKolicinaVM.Kolicina;
            else
                stavkaNarudzbe.Iznos = stavkaNarudzbe.MeniStavka.SnizenaCijena * narudzbaUpdateKolicinaVM.Kolicina;

            narudzba.Cijena += stavkaNarudzbe.Iznos;
            narudzba.BrojStavki += stavkaNarudzbe.Kolicina;

            _dbContext.SaveChanges();

            var response = new
            {
                cijena = narudzba.Cijena,
                kolicina = narudzba.BrojStavki
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Zakljuci(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            OnlineNarudzba narudzba = _dbContext.OnlineNarudzba.Where(n => n.KorisnikID == korisnik.Id && n.Zakljucena == false).SingleOrDefault();
            if (narudzba == null)
                return BadRequest("Ne postoji aktivna narudzba!");

            narudzba.Zakljucena = true;

            narudzba.StatusNarudzbeID = _dbContext.StatusNarudzbe.Where(s => s.Naziv == "Poslano").SingleOrDefault().Id;

            Uposlenik odabraniUposlenik = _dbContext.Uposlenik
                .Where(z => z.AktivneNarudzbe == _dbContext.Uposlenik.Min<Uposlenik>(w => w.AktivneNarudzbe)).FirstOrDefault();
            odabraniUposlenik.AktivneNarudzbe++;
            narudzba.Uposlenik = odabraniUposlenik;
            if (odabraniUposlenik == null)
                return BadRequest("Nemamo uposlenika!");
            _dbContext.SaveChanges();

            return Ok(narudzba.Cijena);
        }
        [HttpGet("{pageNumber}")]
        public IActionResult GetAllPaged(int pageNumber)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            if (korisnik == null)
                return BadRequest("Nemate ovlasti za trazenu akciju!");

            var data = _dbContext.OnlineNarudzba.Where(n => n.KorisnikID == korisnik.Id && n.Zakljucena)
                                                            .Select(n => new NarudzbaGetAllPagedVM()
                                                            {
                                                                id = n.ID,
                                                                cijena = n.Cijena,
                                                                datumNarucivanja = n.DatumNarucivanja.ToString("dd/MM/yyyy hh:mm"),
                                                                status = n.StatusNarudzbe.Naziv,
                                                                stavke = _dbContext.NarudzbaStavka.Where(sn => sn.OnlineNarudzbaId == n.ID).Select(sn => new NarudzbaGetAllPagedVM.Stavka()
                                                                {
                                                                    naziv = sn.MeniStavka.Naziv,
                                                                    kolicina = sn.Kolicina
                                                                }).ToList()
                                                            }).AsQueryable();

            var mojeNarudzbe = PagedList<NarudzbaGetAllPagedVM>.Create(data, pageNumber, 6);

            return Ok(mojeNarudzbe);
        }

        
        [HttpGet("{id}")]
        public ActionResult Naruci(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            if (korisnik == null)
                return BadRequest("Nemate ovlasti za trazenu akciju!");

            OnlineNarudzba narudzba = _dbContext.OnlineNarudzba.Find(id);
            narudzba.StatusNarudzbeID = _dbContext.StatusNarudzbe.Where(s => s.Naziv == "Poslano").SingleOrDefault().Id;
            Uposlenik odabraniUposlenik = _dbContext.Uposlenik
                .Where(z => z.AktivneNarudzbe == _dbContext.Uposlenik.Min<Uposlenik>(w => w.AktivneNarudzbe)).FirstOrDefault();
            odabraniUposlenik.AktivneNarudzbe++;
            narudzba.Uposlenik = odabraniUposlenik;
            if (odabraniUposlenik == null)
                return BadRequest("Nemamo uposlenika!");

            _dbContext.SaveChanges();
            string statusNaziv = _dbContext.OnlineNarudzba.Include(n => n.StatusNarudzbe).Where(n => n.ID == id).SingleOrDefault().StatusNarudzbe.Naziv;
            var response = new
            {
                status = statusNaziv,
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            if (korisnik == null)
                return BadRequest("Nemate ovlasti za trazenu akciju!");

            OnlineNarudzba narudzba = _dbContext.OnlineNarudzba.Find(id);

            List<NarudzbaStavka> stavke = _dbContext.NarudzbaStavka.Where(sn => sn.OnlineNarudzbaId == id).ToList();
           
            _dbContext.RemoveRange(stavke);
            _dbContext.OnlineNarudzba.Remove(narudzba);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
