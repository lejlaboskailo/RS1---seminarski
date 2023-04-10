using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.EntityModels;

namespace WebApplication5.Models
{
    [Table("Uposlenik")]
  
    public class Uposlenik:KorisnickiNalog
    {
        public string Slika { get; set; }
        public int ObavljeneNarudzbe { get; set; }
        public int AktivneNarudzbe { get; set; }
    }
}
