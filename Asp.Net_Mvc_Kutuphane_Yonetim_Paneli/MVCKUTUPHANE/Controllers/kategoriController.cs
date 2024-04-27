using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var kategoriListe = db.TBLKATEGORI.Where(x=>x.KATEGORIDURUM==true).ToList();
            return View(kategoriListe);
        }

        [HttpGet]
        public ActionResult kategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult kategoriEkle(TBLKATEGORI ktgr)
        {
            if (!ModelState.IsValid)
            {
                return View("kategoriEkle");
            }
            db.TBLKATEGORI.Add(ktgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kategoriSil (int id)
        {
            var findKategory = db.TBLKATEGORI.Find(id);
            //db.TBLKATEGORI.Remove(findKategory);
            findKategory.KATEGORIDURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kategoriGetir (int id)
        {
            var veriGetir = db.TBLKATEGORI.Find(id);
            return View("kategoriGetir",veriGetir);
        }


        public ActionResult kategoriGuncelle(TBLKATEGORI ktgr)
        {
            var yeniKtgr = db.TBLKATEGORI.Find(ktgr.ID);
            yeniKtgr.AD = ktgr.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}