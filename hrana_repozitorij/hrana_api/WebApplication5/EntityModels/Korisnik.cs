using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.EntityModels;

namespace WebApplication5.Models
{
  [Table("Korisnik")]
  public class Korisnik:KorisnickiNalog
    {

        public string Slika { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }

        [ForeignKey(nameof(Opstina))]
        public int OpstinaId { get; set; }
        public Opstina Opstina { get; set; }

    }
}
