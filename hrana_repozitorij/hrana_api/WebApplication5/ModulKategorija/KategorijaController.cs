using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Models;
using WebApplication5.ModulKategorija.ViewModels;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ControllerKategorija:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ControllerKategorija(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public Kategorija Snimi([FromBody] KategorijaSnimiVM x)
        {
            Kategorija? objekat;

            if (x.Id == 0)
            {
                objekat = new Kategorija();
                _dbContext.Add(objekat);
            }
            else
            {
                objekat = _dbContext.Kategorija.Find(x.Id);
            }
            objekat.Naziv = x.Naziv;
            _dbContext.SaveChanges();
            return objekat;
        }
        [HttpGet]
        public ActionResult GetALL()
        {
            var data = _dbContext.Kategorija
                .OrderBy(x => x.Naziv)
                .Select(x => new KategorijaGetAllVM()
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                })
                .Take(100);
            return Ok(data.ToList());
        }
    }
}
