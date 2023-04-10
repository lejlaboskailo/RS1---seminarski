using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.EntityModels;

namespace WebApplication5.Models
{
    public class DostavaNalog
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumIsporuke { get; set; }
        [ForeignKey("RestoranId")]
        public int RestoranId { get; set; }
        public Restoran Restoran { get; set; }

        [ForeignKey("UposlenikId")]
        public int UposlenikId { get; set; }
        public Uposlenik Uposlenik { get; set; }
        [ForeignKey("VoziloZaDostavuId")]
        public int VoziloZaDostavuId { get; set; }
        public VoziloZaDostavu VoziloZaDostavu { get; set; }


    }
}
