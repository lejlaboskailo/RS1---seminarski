namespace WebApplication5.KorisnikModul.ViewModels
{
    public class OmiljenaStavkaGetAllPagedVM
    {
        public string kategorija { get; set; }
        public int itemsPerPage { get; set; } = 8;
        public int pageNumber { get; set; } = 1;
    }
}
