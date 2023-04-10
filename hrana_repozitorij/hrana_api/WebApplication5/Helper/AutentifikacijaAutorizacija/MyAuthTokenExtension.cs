using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using WebApplication5.Data;
using WebApplication5.EntityModels;

namespace WebApplication5.Helper.AutentifikacijaAutorizacija
{
  public static class MyAuthTokenExtension
  {
    public class LoginInformacije
    {
      public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
      {
        this.autentifikacijaToken = autentifikacijaToken;
      }
      [JsonIgnore]
      public KorisnickiNalog korisnickiNalog => autentifikacijaToken?.KorisnickiNalog;
      public AutentifikacijaToken autentifikacijaToken { get; set; }
      public bool isLogiran => korisnickiNalog != null;
      public bool isPermsijaKorisnik => isLogiran && (korisnickiNalog.isKorisnik);
      public bool isPermsijaAdministrator => isLogiran && (korisnickiNalog.isAdministrator);
      public bool isPermisijaUposlenik => isLogiran && (korisnickiNalog.isUposlenik);
      public bool isPermisijaGost => !isLogiran;

    }
    public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
    {
      AutentifikacijaToken token = httpContext.GetAuthToken();
      return new LoginInformacije(token);
    }
    public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
    {
      string token = httpContext.GetMyAuthToken();
      ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

      AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
          .Include(s => s.KorisnickiNalog)
          .SingleOrDefault(x => token != null && x.Vrijednost == token);

      return korisnickiNalog;
    }

    public static string GetMyAuthToken(this HttpContext httpContext)
    {
      string token = httpContext.Request.Headers["autentifikacija-token"];
      return token;
    }
  }
}
