using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Kategorija
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}
