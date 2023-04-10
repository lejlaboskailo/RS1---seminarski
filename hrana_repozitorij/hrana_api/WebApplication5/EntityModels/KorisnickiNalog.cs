using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Models;

namespace WebApplication5.EntityModels
{
  public class KorisnickiNalog
  {
    [Key]
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string KorisnickoIme { get; set; }
    public string Lozinka { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public Korisnik Korisnik => this as Korisnik;
    [JsonIgnore]
    public Uposlenik Uposlenik => this as Uposlenik;
    [JsonIgnore]
    public Administrator Administrator => this as Administrator;
    public bool isKorisnik { get; set; }
    public bool isAdministrator { get; set; }
    public bool isUposlenik { get; set; }
  
  }
}
