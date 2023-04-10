using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Migrations;
using WebApplication5.Models;
using WebApplication5.ModulMeni.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication5.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Hosting;
using MathNet.Numerics.Distributions;
using Microsoft.EntityFrameworkCore;
using XAct;

namespace WebApplication5.ModulMeni.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MeniController:ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment WebHostEnvironment;
        public MeniController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            WebHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public List<MeniStavka> GetAll()
        {
            return _dbContext.Meni.ToList();
        }


        [HttpPost("{id}")]
        public ActionResult AddOcjena(int id, [FromBody] MeniAddOcjenaVM meniAddOcjenaVM)
        {
            MeniStavka meniStavka = _dbContext.Meni.Find(id);
            if (meniStavka != null)
            {
                if (meniStavka.Ocjena == 0) meniStavka.Ocjena = meniAddOcjenaVM.ocjena; //ukoliko je nemi stavka tek dodana
                meniStavka.Ocjena += meniAddOcjenaVM.ocjena;
                meniStavka.Ocjena = (float)Math.Round(meniStavka.Ocjena / 2, 2);
                _dbContext.SaveChanges();
            }

            return Ok(meniStavka);
        }

        [HttpPost]
        public string UploadFile(MeniGetAllPagedVM x)
        {
            string fileName = null;
            if (x.MeniSlika != null)
            {
                foreach (IFormFile meni in x.MeniSlika)
                {
                    string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Slike");
                    fileName = Guid.NewGuid().ToString() + "-" + meni.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        meni.CopyTo(fileStream);
                    }
                }
            }
            return fileName;
        }

        [HttpGet]
        public List<MeniGetAllPagedVM> GetAllPaged(string nazivKategorije)
        {
            List<MeniGetAllPagedVM> pagedStavke = _dbContext.Meni
                                            .Where(ms => ms.Kategorija.Naziv == nazivKategorije)
                                            .Select(ms => new MeniGetAllPagedVM()
                                            {
                                                id = ms.ID,
                                                naziv = ms.Naziv,
                                                opis = ms.Opis,
                                                cijena = ms.Cijena,
                                                slika = ms.Slika,
                                                izdvojeno = ms.Izdvojeno,
                                                snizenaCijena = ms.SnizenaCijena,
                                                ocjena = ms.Ocjena,
                                                nazivKategorije = ms.Kategorija.Naziv
                                            }).ToList();
            return pagedStavke;
        }


        // [HttpPost]
        //public IActionResult GetAllPagedLog([FromBody] MeniGAPLogInfoVM meniGAPLogInfoVM)
        //{
        //    if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
        //        return BadRequest("nije logiran");

        //    Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;
        //    if (korisnik == null)
        //        return null;
        //    List<MeniGetAllPagedLogVM> pagedStavke = _dbContext.Meni
        //                                    .Where(ms => ms.Kategorija.Naziv == meniGAPLogInfoVM.kategorija)
        //                                    .Select(ms => new MeniGetAllPagedLogVM()
        //                                    {
        //                                        id = ms.ID,
        //                                        naziv = ms.Naziv,
        //                                        opis = ms.Opis,
        //                                        cijena = ms.Cijena,
        //                                        slika = ms.Slika,
        //                                        izdvojeno = ms.Izdvojeno,
        //                                        snizenaCijena = ms.SnizenaCijena,
        //                                        ocjena = ms.Ocjena,
        //                                        nazivKategorije = ms.Kategorija.Naziv,
        //                                    }).ToList();
        //    return Ok(pagedStavke);
        //}

        [HttpGet("{id}")]
        public MeniUpdateVM GetById(int id)
        {
            MeniStavka meniStavka = _dbContext.Meni.Find(id);
            if (meniStavka != null)
            {
                MeniUpdateVM odabranaStavka = new MeniUpdateVM()
                {
                    id = meniStavka.ID,
                    naziv = meniStavka.Naziv,
                    opis = meniStavka.Opis,
                    cijena = meniStavka.Cijena,
                    snizenaCijena = meniStavka.SnizenaCijena,
                    meniKategorijaId = meniStavka.KategorijaId,
                    slika = meniStavka.Slika
                };
                return odabranaStavka;
            }
            return null;
        }
    }
}
