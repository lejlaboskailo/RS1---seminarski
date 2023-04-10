using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.Models;

namespace WebApplication5.EntityModels
{
  public class KorpaStavke
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey("MeniId")]
    public int MeniId { get; set; }
    public MeniStavka Meni { get; set; }
    public int Kolicina { get; set; }
    public string KorpaId { get; set; }  

  }
}
