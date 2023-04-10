using System.ComponentModel.DataAnnotations;

namespace WebApplication5.EntityModels
{
  public class Opstina
  {
    [Key]
    public int Id { get; set; }
    public string Naziv { get; set; }
  }
}
