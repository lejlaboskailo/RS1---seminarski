namespace WebApplication5.ModulMeni.ViewModels
{
    public class MeniUpdateVM
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public float cijena { get; set; }
        public float snizenaCijena { get; set; }
        public int meniKategorijaId { get; set; }
        public string slika { get; set; }
    }
}
