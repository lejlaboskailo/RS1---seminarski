using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class UposlenikObavijesti
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UposlenikId")]
        public Uposlenik Uposlenik { get; set; }
        public int UposlenikId { get; set; }
        public Obavijesti Obavijesti { get; set; }
        [ForeignKey("ObavijestiId")]
        public int ObavijestiId { get; set; }


    }
}
