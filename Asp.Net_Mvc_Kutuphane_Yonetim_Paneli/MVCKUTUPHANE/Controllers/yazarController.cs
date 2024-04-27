using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class yazarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: yazar
        public ActionResult Index(string p)
        {
            //var yazarListe = db.TBL_YAZAR.ToList();
            var yazarListe = from k in db.TBL_YAZAR select k;
            if (!string.IsNullOrEmpty(p))
            {
                yazarListe = yazarListe.Where(x=>x.AD.Contains(p));
            }
            return View(yazarListe.ToList());
        }

        [HttpGet]
        public ActionResult yazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yazarEkle(TBL_YAZAR p)
        {
            if (!ModelState.IsValid)
            {
                return View("yazarEkle");
            }
            db.TBL_YAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult yazarSil (int id)
        {
            var findAuthor = db.TBL_YAZAR.Find(id);
            db.TBL_YAZAR.Remove(findAuthor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult yazarGetir (int id)
        {
            var bilgiler = db.TBL_YAZAR.Find(id);
            return View("yazarGetir", bilgiler);
        }

        public ActionResult yazarGuncelle(TBL_YAZAR p)
        {
            var mevcut = db.TBL_YAZAR.Find(p.ID);
            mevcut.AD = p.AD;
            mevcut.SOYAD = p.SOYAD;
            mevcut.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult yazarKitaplar(int id)
        {
            var yazarDetay = db.TBLKITAP.Where(x => x.YAZAR == id).ToList();
            var yazarBilgi = db.TBL_YAZAR.Where(x => x.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.yzr = yazarBilgi;
            return View(yazarDetay);
        }
    }
}