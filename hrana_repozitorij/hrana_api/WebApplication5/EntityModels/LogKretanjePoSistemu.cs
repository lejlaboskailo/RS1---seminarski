using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.EntityModels
{
  public class LogKretanjePoSistemu
  {
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(korisnik))]
    public int korisnikId { get; set; }
    public KorisnickiNalog korisnik { get; set; }
    public string QueryPath { get; set; }
    public string PostData { get; set; }
    public DateTime Vrijeme { get; set; }
    public string IpAdresa { get; set; }
    public string ExceptionMessage { get; set; }
    public bool isException { get; set; }
  }
}
