using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class StavkaUlaza
    {
        [Key]
        public int Id { get; set; }
        public string Kolicina { get; set; }
        [ForeignKey("UlazUSkaldisteId")]
        public UlazUSkladiste UlazUSkladiste { get; set; }
        public int UlazUSkladisteId { get; set; }
        [ForeignKey("MeniId")]
        public MeniStavka Meni { get; set; }
        public int MeniId { get; set; }
    }
}
