namespace WebApplication5.KorisnikModul.ViewModels
{
    public class OmiljenaStavkaGetAllVM
    {
        public int omiljenaStavkaId { get; set; }
        public int KorisnikID { get; set; }
        public int id { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public float cijena { get; set; }
        public string slika { get; set; }
        public bool izdvojeno { get; set; }
        public float snizenaCijena { get; set; }
        public float ocjena { get; set; }
        public string nazivGrupe { get; set; }
    }
}
