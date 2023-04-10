using MailKit;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebApplication5.Data;
using WebApplication5.EntityModels;
using WebApplication5.Helper.AutentifikacijaAutorizacija;
using WebApplication5.Helper.ErrorHandler;
using WebApplication5.KorisnikModul.ViewModels;
using WebApplication5.Models;
using WebApplication5.Service;

namespace WebApplication5.KorisnikModul.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OmiljenaStavkaController:ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private IEmailService _mailService;

        public OmiljenaStavkaController(ApplicationDbContext dbContext, IEmailService mailService)
        {
            _dbContext = dbContext;
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult Add([FromBody]OmiljenaStavkaAddVM omiljenaStavkaAddVM)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            if (korisnik == null)
                return BadRequest("Nemate ovlasti za trazenu akciju!");

            MeniStavka meniStavka = _dbContext.Meni.Find(omiljenaStavkaAddVM.meniStavkaId);
            if (meniStavka == null)
                return BadRequest("Nepostojeca meni stavka!");

            OmiljenaStavka omiljenaStavka = new OmiljenaStavka()
            {
                KorisnikID = korisnik.Id,
                MeniStavkaID = omiljenaStavkaAddVM.meniStavkaId,
            };

            _dbContext.OmiljenaStavka.Add(omiljenaStavka);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult<PagedList<OmiljenaStavkaGetAllVM>> GetAllPaged([FromBody] OmiljenaStavkaGetAllPagedVM omiljenaStavkaGetAllPagedVM)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            if (korisnik == null)
                return BadRequest("Nemate ovlasti za trazenu akciju!");


            var data = _dbContext.OmiljenaStavka.Where(os => os.KorisnikID == korisnik.Id)
                                                            .Select(os => new OmiljenaStavkaGetAllVM()
                                                            {
                                                                omiljenaStavkaId = os.ID,
                                                                id = os.MeniStavkaID,
                                                                naziv = os.MeniStavka.Naziv,
                                                                opis = os.MeniStavka.Opis,
                                                                cijena = os.MeniStavka.Cijena,
                                                                slika = os.MeniStavka.Slika,
                                                                izdvojeno = os.MeniStavka.Izdvojeno,
                                                                snizenaCijena = os.MeniStavka.SnizenaCijena,
                                                                ocjena = os.MeniStavka.Ocjena,
                                                                nazivGrupe = os.MeniStavka.Kategorija.Naziv,
                                                                KorisnikID= os.KorisnikID
                                                             
                                                            }).AsQueryable();

            //var data1 = _dbContext.OmiljenaStavka.Where(os => os.KorisnikID == korisnik.Id)
            //                                    .Select(os => new OmiljenaStavkaGetAllVM()
            //                                    {
            //                                        omiljenaStavkaId = os.ID,
            //                                        id = os.MeniStavkaID,
            //                                        naziv = os.MeniStavka.Naziv,
            //                                        opis = os.MeniStavka.Opis,
            //                                        cijena = os.MeniStavka.Cijena,
            //                                        slika = os.MeniStavka.Slika,
            //                                        izdvojeno = os.MeniStavka.Izdvojeno,
            //                                        snizenaCijena = os.MeniStavka.SnizenaCijena,
            //                                        ocjena = os.MeniStavka.Ocjena,
            //                                        nazivGrupe = os.MeniStavka.Kategorija.Naziv
            //                                    }).Where(os => os.nazivGrupe == omiljenaStavkaGetAllPagedVM.kategorija).AsQueryable();

            var queryableResult = data.ToList();

            if (queryableResult.Count() == 0)
            {
                throw new ErrorResponse("Data not found");
            }

            var list = new List<OmiljenaStavkaGetAllVM>();
            list = queryableResult;


            var filterLista = new List<OmiljenaStavkaGetAllVM>();

            if (omiljenaStavkaGetAllPagedVM.kategorija != "")
            {
                filterLista = list.Where(q => q.nazivGrupe == omiljenaStavkaGetAllPagedVM.kategorija).ToList();
            }


            //throw new Exception("No items found");

            //if (data.Count() == 0)
            //{
            //    throw new ErrorResponse("Data not found");
            //}

            var omiljeneStavke = PagedList<OmiljenaStavkaGetAllVM>.Create(filterLista.AsQueryable(), omiljenaStavkaGetAllPagedVM.pageNumber, omiljenaStavkaGetAllPagedVM.itemsPerPage);


            //if (data.Count() == 0)
            //{
            //    throw new ErrorResponse(404, "Data not found");
            //}

            return Ok(omiljeneStavke);
        }



        //public ActionResult<PagedList<OmiljenaStavkaGetAllVM>> GetAllPaged([FromBody] OmiljenaStavkaGetAllPagedVM omiljenaStavkaGetAllPagedVM)
        //{
        //    if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
        //        return BadRequest("nije logiran");

        //    Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

        //    if (korisnik == null)
        //        return BadRequest("Nemate ovlasti za trazenu akciju!");


        //    var data = _dbContext.OmiljenaStavka.Where(os => os.KorisnikID == korisnik.Id)
        //                                                    .Select(os => new OmiljenaStavkaGetAllVM()
        //                                                    {
        //                                                        omiljenaStavkaId = os.ID,
        //                                                        id = os.MeniStavkaID,
        //                                                        naziv = os.MeniStavka.Naziv,
        //                                                        opis = os.MeniStavka.Opis,
        //                                                        cijena = os.MeniStavka.Cijena,
        //                                                        slika = os.MeniStavka.Slika,
        //                                                        izdvojeno = os.MeniStavka.Izdvojeno,
        //                                                        snizenaCijena = os.MeniStavka.SnizenaCijena,
        //                                                        ocjena = os.MeniStavka.Ocjena,
        //                                                        nazivGrupe = os.MeniStavka.Kategorija.Naziv
        //                                                    }).AsQueryable();

        //    var data1 = _dbContext.OmiljenaStavka
        //                                        .Select(os => new OmiljenaStavkaGetAllVM()
        //                                        {
        //                                            omiljenaStavkaId = os.ID,
        //                                            id = os.MeniStavkaID,
        //                                            naziv = os.MeniStavka.Naziv,
        //                                            opis = os.MeniStavka.Opis,
        //                                            cijena = os.MeniStavka.Cijena,
        //                                            slika = os.MeniStavka.Slika,
        //                                            izdvojeno = os.MeniStavka.Izdvojeno,
        //                                            snizenaCijena = os.MeniStavka.SnizenaCijena,
        //                                            ocjena = os.MeniStavka.Ocjena,
        //                                            nazivGrupe = os.MeniStavka.Kategorija.Naziv
        //                                        }).Where(os => os.nazivGrupe == omiljenaStavkaGetAllPagedVM.kategorija).AsQueryable();

        //    var queryableResult = data.ToList();

        //    if (queryableResult.Count() == 0)
        //    {
        //        throw new ErrorResponse("Data not found");
        //    }


        //    //throw new Exception("No items found");

        //    //if (data.Count() == 0)
        //    //{
        //    //    throw new ErrorResponse("Data not found");
        //    //}

        //    var omiljeneStavke = PagedList<OmiljenaStavkaGetAllVM>.Create(data, omiljenaStavkaGetAllPagedVM.pageNumber, omiljenaStavkaGetAllPagedVM.itemsPerPage);


        //    //if (data.Count() == 0)
        //    //{
        //    //    throw new ErrorResponse(404, "Data not found");
        //    //}

        //    return Ok(omiljeneStavke);
        //}

        [HttpGet("{id}")]

        public IActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            OmiljenaStavka omiljenaStavka = _dbContext.OmiljenaStavka.Find(id);
            if (omiljenaStavka == null)
                return BadRequest("Nepostojeca omiljena stavka!");

            _dbContext.OmiljenaStavka.Remove(omiljenaStavka);
            _dbContext.SaveChanges();
            return Ok(omiljenaStavka);
        }

        [HttpPost]
        public IActionResult DeleteById([FromBody] OmiljenaStavkaInfoVM omiljenaStavkaInfoVM)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            OmiljenaStavka omiljenaStavka = _dbContext.OmiljenaStavka.Where(os => os.KorisnikID == korisnik.Id && os.MeniStavkaID == omiljenaStavkaInfoVM.stavkaId).SingleOrDefault();
            if (omiljenaStavka == null)
                return BadRequest("Nepostojeca omiljena stavka!");

            _dbContext.OmiljenaStavka.Remove(omiljenaStavka);
            _dbContext.SaveChanges();
            return Ok(omiljenaStavka);
        }
    }
}
