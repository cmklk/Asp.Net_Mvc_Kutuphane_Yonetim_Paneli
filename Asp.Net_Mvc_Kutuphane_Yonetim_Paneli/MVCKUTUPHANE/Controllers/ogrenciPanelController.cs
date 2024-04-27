using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    [Authorize]
    public class ogrenciPanelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: ogrenciPanel
        [HttpGet]
        public ActionResult Index(TBL_UYE t)
        {
            var kullaniciMail = (string)Session["MAIL"];
            //  var degerler = db.TBL_UYE.FirstOrDefault(x => x.MAIL == kullaniciMail);
            var degerler = db.tbl_duyurular.ToList();
            var d1 = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.AD).FirstOrDefault();
            ViewBag.ad = d1;

            var d2 = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.SOYAD).FirstOrDefault();
            ViewBag.soyad = d2;

            var d3 = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.OKUL).FirstOrDefault();
            ViewBag.okul = d3;

            var d4 = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.TELEFON).FirstOrDefault();
            ViewBag.telefon = d4;


            var d5 = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.KULLANICIADI).FirstOrDefault();
            ViewBag.kullanici = d5;

            var d6 = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.MAIL).FirstOrDefault();
            ViewBag.mail = d6;

            var d7 = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.FOTOGRAF).FirstOrDefault();
            ViewBag.fotograf = d7;

            var uyeID = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.ID).FirstOrDefault();
            var kitap = db.TBLHAREKET.Where(x => x.UYE == uyeID).Count();
            ViewBag.kitapSayi = kitap;


            var uyeMesaj = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.MAIL).FirstOrDefault();
            var uyeGelenMesaj = db.TBL_MESAJLAR.Where(x => x.ALICI == uyeMesaj).Count();
            ViewBag.gelen = uyeGelenMesaj;



            var uyeMesaj2 = db.TBL_UYE.Where(x => x.MAIL == kullaniciMail.ToString()).Select(x => x.MAIL).FirstOrDefault();
            var uyeGonderen = db.TBL_MESAJLAR.Where(x => x.GONDEREN == uyeMesaj2).Count();
            ViewBag.gonderen = uyeGonderen;
              return View(degerler);
        }


        
        [HttpPost] // güncelleme işlemi yapıldı.
        public ActionResult Index2(TBL_UYE p)
        {
            var kullanici = (string)Session["MAIL"];
            var uye = db.TBL_UYE.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kitaplarim()
        {
            var uyeMail = (string)Session["MAIL"];
            var id = db.TBL_UYE.Where(x => x.MAIL == uyeMail.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);  
        }


        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("girisYap","Login");
        }


     


        public PartialViewResult partialDuyuru()
        {
            return PartialView();
        }


        public PartialViewResult partialUyeBilgi()
        {
            var kullanici = (string)Session["MAIL"];
            var kullaniciUye = db.TBL_UYE.Where(x => x.MAIL == kullanici).Select(y => y.ID).FirstOrDefault();
            var uyeBul = db.TBL_UYE.Find(kullaniciUye);
            return PartialView("partialUyeBilgi", uyeBul);
        }
            
        }
    }
