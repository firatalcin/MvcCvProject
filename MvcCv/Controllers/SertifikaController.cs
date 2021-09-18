using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika

        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();

        public ActionResult SertifikaListele()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult sertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.Id == id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult sertifikaGetir(TblSertifikalarim t)
        {
            var sertifika = repo.Find(x => x.Id == t.Id);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Sertifika = t.Sertifika;
            sertifika.Kurum = t.Kurum;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("SertifikaListele");          
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("SertifikaListele");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.Id == id);
            repo.TDelete(sertifika);
            return RedirectToAction("SertifikaListele");
        }
    }
}