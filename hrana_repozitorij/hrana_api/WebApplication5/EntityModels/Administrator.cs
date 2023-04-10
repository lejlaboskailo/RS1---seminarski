using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.EntityModels
{
  [Table("Administrator")]
  public class Administrator:KorisnickiNalog
  {
    public DateTime DatumKreiranja { get; set; }

  }
}
