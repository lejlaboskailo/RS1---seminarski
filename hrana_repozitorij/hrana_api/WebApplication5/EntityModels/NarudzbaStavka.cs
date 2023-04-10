using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace WebApplication5.Models
{
    public class NarudzbaStavka
    {
        [Key]
        public int Id { get; set; }
        public int Kolicina { get; set; }
        [ForeignKey("MeniStavkaId")]
        public MeniStavka MeniStavka { get; set; }
        public int MeniStavkaId { get; set; }
        public float Iznos { get; set; }

        [ForeignKey("OnlineNarudzbaId")]
        public OnlineNarudzba OnlineNarudzba { get; set; }

        public int OnlineNarudzbaId { get; set; }

    }
}
