using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            var iadeListe = db.TBLHAREKET.Where(x=>x.ISLEMDURUM==false).ToList();
            return View(iadeListe);
        }


        [HttpGet]
        public ActionResult oduncVer()
        {
            List<SelectListItem> personelAd = (from x in db.TBLPERSONEL.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.PERSONEL,
                                                   Value = x.ID.ToString(),
                                               }).ToList();
            ViewBag.personel = personelAd;



            List<SelectListItem> uye = (from x in db.TBL_UYE.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD +"" +x.SOYAD,
                                            Value = x.ID.ToString(),
                                        }).ToList();

            ViewBag.uyeBilgi = uye;



            List<SelectListItem> kitaplar = (from x in db.TBLKITAP.Where(x=>x.DURUM==true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString(),
                                             }).ToList();

            ViewBag.ktp = kitaplar;


            return View();
        }

        [HttpPost]
        public ActionResult oduncVer(TBLHAREKET p)
        {

            var d1 = db.TBL_UYE.Where(x => x.ID == p.TBL_UYE.ID).FirstOrDefault();
            var d2 = db.TBLPERSONEL.Where(x => x.ID == p.TBLPERSONEL.ID).FirstOrDefault();
            var d3 = db.TBLKITAP.Where(x => x.ID == p.TBLKITAP.ID).FirstOrDefault();

            p.TBL_UYE = d1;
            p.TBLPERSONEL = d2;
            p.TBLKITAP = d3;

            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult oduncIadeGetir(TBLHAREKET p)
        {
            var iadeBilgileri = db.TBLHAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(iadeBilgileri.IADETARIH.ToString());
            DateTime d2 = DateTime.Parse(DateTime.Now.ToShortDateString());

            TimeSpan d3;
            d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("oduncIadeGetir", iadeBilgileri);
        }

        public ActionResult oduncGuncelle (TBLHAREKET p)
        {
            var hareket = db.TBLHAREKET.Find(p.ID);
            hareket.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hareket.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}