using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();

        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            p.Durum = true;
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.Id == id);
            return View(hesap);
        }

        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.Id == p.Id);
            hesap.Ad = p.Ad;
            hesap.Icon = p.Icon;
            hesap.Link = p.Link;
            hesap.Durum = true;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaSil(int id)
        {
            var hesap = repo.Find(x => x.Id == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}