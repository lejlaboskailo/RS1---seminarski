using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.EntityModels;
using WebApplication5.Helper;
using WebApplication5.Helper.ErrorHandler;
using WebApplication5.Modul_Autentifikacija.ViewModels;
using static WebApplication5.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;

namespace WebApplication5.ModulAutentifikacija.Controllers
{

    [ApiController]
  [Route("[controller]/[action]")]
    
    public class AutentifikacijaController : ControllerBase
  {
    private ApplicationDbContext _dbContext;
   

        public AutentifikacijaController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    

    [HttpPost]
    public ActionResult<LoginInformacije> Login([FromBody] LoginVM loginVM)
    {
      KorisnickiNalog logiraniKorisnik = _dbContext.KorisnickiNalog
          .FirstOrDefault(k => k.KorisnickoIme != null && k.KorisnickoIme == loginVM.korisnickoIme && k.Lozinka == loginVM.lozinka);

      if (logiraniKorisnik == null)
      {
        return new LoginInformacije(null);
      }

       string randomString = TokenGenerator.Generate(10);


      var noviToken = new AutentifikacijaToken()
      {
        IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
        Vrijednost = randomString,
        KorisnickiNalog = logiraniKorisnik,
        vrijemeEvidentiranja = DateTime.Now
      };

      _dbContext.Add(noviToken);
      _dbContext.SaveChanges();

      return new LoginInformacije(noviToken);
    }

    [HttpPost]
    public ActionResult Logout()
    {
      AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();
      if (autentifikacijaToken == null)
        return Ok();

      _dbContext.Remove(autentifikacijaToken);
      _dbContext.SaveChanges();
      return Ok();
    }

    [HttpGet]
    public ActionResult<AutentifikacijaToken> Get()
    {
      AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();
      return autentifikacijaToken;
    }

    [HttpGet("{id}")]
    public KorisnickiNalog GetUser(int id)
    {
      return _dbContext.KorisnickiNalog.Find(id);
    }


  }
}
