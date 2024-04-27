using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MVCKUTUPHANE.Controllers
{
    public class uyeController : Controller
    {
        // GET: uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa=1)
        {
            // var uyeList = db.TBL_UYE.ToList();
            var uyeList = db.TBL_UYE.ToList().ToPagedList(sayfa, 2);
            return View(uyeList);
        }


        [HttpGet]
        public ActionResult uyeEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult uyeEkle(TBL_UYE p) // view dan gelecek olan değerlerim.
        {
            if (!ModelState.IsValid) // validasyon işlemleri doğru değilse beni bu sayfada tut. Eğer doğru ise ekleme işlemini yap. Index sayfasına git.
            {
                return View("uyeEkle");
            }
            db.TBL_UYE.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult uyeSil(int id)
        {
            var findPerson = db.TBL_UYE.Find(id);
            db.TBL_UYE.Remove(findPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult uyeVeriGetir(int id)
        {
            var uyeVeri = db.TBL_UYE.Find(id);
            return View ("uyeVeriGetir", uyeVeri);

        }


        public ActionResult uyeGuncelle(TBL_UYE p)
        {
            var mevcutUye = db.TBL_UYE.Find(p.ID);
            mevcutUye.AD = p.AD;
            mevcutUye.SOYAD = p.SOYAD;
            mevcutUye.MAIL = p.MAIL;
            mevcutUye.KULLANICIADI = p.KULLANICIADI;
            mevcutUye.SIFRE = p.SIFRE;
            mevcutUye.TELEFON = p.TELEFON;
            mevcutUye.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult uyeGecmis(int id)
        {
            var gecmis = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uye = db.TBL_UYE.Where(x => x.ID == id).Select(z => z.AD+" "+z.SOYAD).FirstOrDefault();
            ViewBag.uyekisi= uye;
            return View(gecmis);
        }
    }
}