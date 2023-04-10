using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.Models;

namespace WebApplication5.EntityModels
{
  public class Rezervacija
  {
    [Key]
    public int Id { get; set; }
    public int BrojOsoba { get; set; }
    public int BrojStolova { get; set; }
    public bool Obavljena { get; set; }
    public string Poruka { get; set; }
    public DateTime VrijemeRezrvacije { get; set; }

    [ForeignKey(nameof(Korisnik))]  
    public int KorisnikId { get; set; }
    public Korisnik Korisnik { get; set; }

    [ForeignKey(nameof(Kategorija))]
    public int KategorijaId { get; set; }
    public Kategorija Kategorija { get; set; }
    
  }
}
