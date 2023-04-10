using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.EntityModels
{
  public class Restoran
  {
    [Key]
    public int Id { get; set; }
    public string Adresa { get; set; }
    public string BrojTelefona { get; set; }

    [ForeignKey("OpstinaId")]
    public int OpstinaId { get; set; }
    public Opstina Opstina { get; set; }
    public string RadnoVrijemeRedovno { get; set; }
    public string RadnoVrijemeVikend { get; set; }
  }
}
