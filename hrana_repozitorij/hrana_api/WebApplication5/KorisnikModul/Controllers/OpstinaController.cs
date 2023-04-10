using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.EntityModels;
using WebApplication5.Helper.AutentifikacijaAutorizacija;

namespace WebApplication5.KorisnikModul.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OpstinaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public OpstinaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<CmbStavke> GetByAll()
        {
            var data = _dbContext.Opstina.OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.Id,
                    opis = s.Naziv
                }).AsQueryable();

            return data.Take(100).ToList();
        }

        [HttpPost]
        public ActionResult Add(string naziv)
        {
            Opstina novaOpstina = new Opstina() { Naziv = naziv };
            _dbContext.Opstina.Add(novaOpstina);
            _dbContext.SaveChanges();
            return Ok(novaOpstina.Id);
        }
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Opstina opstina = _dbContext.Opstina.Find(id);

            if (opstina == null)//|| id == 1
                return BadRequest("pogresan ID");

            _dbContext.Remove(opstina);

            _dbContext.SaveChanges();
            return Ok(opstina);
        }
    }
}
