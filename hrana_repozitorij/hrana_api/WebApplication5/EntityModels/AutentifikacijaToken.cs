using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.EntityModels
{
  public class AutentifikacijaToken
  {
    [Key]
    public int Id { get; set; }
    public string Vrijednost { get; set; }
    [ForeignKey(nameof(KorisnickiNalog))]
    public int KorisnickiNalogId {get;set;}
    public KorisnickiNalog KorisnickiNalog { get; set; }
    public DateTime vrijemeEvidentiranja { get; set; }
    public string IpAdresa { get; set; }
  }
}
