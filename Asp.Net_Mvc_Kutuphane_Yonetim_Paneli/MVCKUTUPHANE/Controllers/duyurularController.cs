using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class duyurularController : Controller
    {
        // GET: duyurular

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var duyuru = db.tbl_duyurular.ToList();
            return View(duyuru);
        }

        [HttpPost]
        public ActionResult duyuruEkle(tbl_duyurular p)
        {

            db.tbl_duyurular.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
         public ActionResult duyuruEkle()
        {
            return View();
        }


        public ActionResult duyuruSil(int id)
        {
            var duyuru = db.tbl_duyurular.Find(id);
            db.tbl_duyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult duyuruGetir(tbl_duyurular p)
        {
            var duyuruBilgi = db.tbl_duyurular.Find(p.ID);
            return View("duyuruGetir",duyuruBilgi);
        }

        
        public ActionResult guncelle (tbl_duyurular p)
        {
            var mevcutDuyuru = db.tbl_duyurular.Find(p.ID); // ilgili seçtiğimiz duyuru.
            mevcutDuyuru.KATEGORI = p.KATEGORI;
            mevcutDuyuru.ICERIK = p.ICERIK;
            mevcutDuyuru.TARİH = p.TARİH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}