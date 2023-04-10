using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace WebApplication5.Models
{
    public class UlazUSkladiste
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public float KolicinaUlaza { get; set; }
        public string ImeDobavljaca { get; set; }
        public DateTime DatumPrijema { get; set; }
        [ForeignKey(nameof(UposlenikId))]
        public Uposlenik Uposlenik { get; set; }
        public int UposlenikId { get; set; }

    }
}



