namespace WebApplication5.ModulMeni.ViewModels
{
    public class MeniGetAllPagedLogVM
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public float cijena { get; set; }
        public string slika { get; set; }
        public bool izdvojeno { get; set; }
        public float snizenaCijena { get; set; }
        public float ocjena { get; set; }
        public string nazivKategorije { get; set; }
    }
}
