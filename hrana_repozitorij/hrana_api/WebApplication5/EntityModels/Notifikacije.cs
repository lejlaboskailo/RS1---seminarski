using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Notifikacije
    {
        [Key]
        public int Id { get; set; }
        public string Poruka { get; set; }
        [ForeignKey("OnlineGostId")]
        public Korisnik OnlineGost { get; set; }
        public int OnlineGostId { get; set; }
    }
}
