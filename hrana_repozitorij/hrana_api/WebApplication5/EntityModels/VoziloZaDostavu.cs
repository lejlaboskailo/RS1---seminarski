using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class VoziloZaDostavu
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
    }
}
