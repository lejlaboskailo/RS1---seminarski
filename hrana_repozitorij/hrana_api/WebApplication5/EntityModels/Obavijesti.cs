using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Obavijesti
    {
        [Key]
        public int Id { get; set; }
        public string Poruka { get; set; }
        public DateTime Datum { get; set; }
        public IEnumerable<UposlenikObavijesti> Uposlenik { get; set; }
    }
}
