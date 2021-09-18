using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
     
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
       

        public ActionResult YetenekListele()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("YetenekListele");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.İd == id);
            repo.TDelete(yetenek);
            return RedirectToAction("YetenekListele");
        }

        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.İd == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim t)
        {
            var y = repo.Find(x => x.İd == t.İd);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("YetenekListele");
        }
    }
}