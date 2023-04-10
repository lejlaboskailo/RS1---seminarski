using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class PonudaStavka
    {
        [Key]
        public int Id { get; set; }
        public string DostupnaKolicina { get; set; }
        [ForeignKey("MeniId")]
        public MeniStavka Meni { get; set; }
        public int MeniId { get; set; }
        [ForeignKey("DnevnaPonudaId")]
        public DnevnaPonuda DnevnaPonuda { get; set; }
        public int? DnevnaPonudaId { get; set; }
    }
}
