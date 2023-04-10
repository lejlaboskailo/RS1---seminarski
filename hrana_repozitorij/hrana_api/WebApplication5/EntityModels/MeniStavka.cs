using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
  public class MeniStavka
  {
    [Key]
    public int ID { get; set; }
    public string Naziv { get; set; }
    public string Opis { get; set; }
    public float Cijena { get; set; }
    public string Slika { get; set; }
    public bool Izdvojeno { get; set; }
    public float SnizenaCijena { get; set; }
    public float Ocjena { get; set; }
    
    [ForeignKey("KategorijaId")]
    public int KategorijaId { get; set; }
    public Kategorija Kategorija { get; set; }
  }
}
