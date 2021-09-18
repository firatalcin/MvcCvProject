using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var deger = repo.Find(x => x.Id == 1);
            deger.Ad = p.Ad;
            deger.Soyad = p.Soyad;
            deger.Mail = p.Mail;
            deger.Adres = p.Adres;
            deger.Resim = p.Resim;
            deger.Aciklama = p.Aciklama;
            deger.Telefon = p.Telefon;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}