using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class DnevnaPonuda
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Cijena { get; set; }
    }
}
