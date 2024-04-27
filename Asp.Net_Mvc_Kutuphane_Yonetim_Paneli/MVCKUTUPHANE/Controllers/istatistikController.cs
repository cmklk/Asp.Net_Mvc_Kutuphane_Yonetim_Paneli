using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBL_UYE.Count();
            var deger2 = db.TBL_YAZAR.Count();
            var deger3 = db.TBLKITAP.Count();
            var deger4 = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).Count();
            ViewBag.dgr = deger1;
            ViewBag.dgr1 = deger2;
            ViewBag.dgr2 = deger3;
            ViewBag.dgr3 = deger4;
           return View();
        }

        public ActionResult hava()
        {
            return View();
        }


        public ActionResult linqKartlar()
        {
            var deger1 = db.TBLKITAP.Count();
            var deger2 = db.TBL_UYE.Count();
            var deger3 = db.TBLPERSONEL.Count();
            var deger4 = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).Count();
            var deger5 = db.TBLKATEGORI.Count();
            var deger6 = db.enAktifUye().FirstOrDefault();
            var deger7 = db.okunanKitap().FirstOrDefault();
            var deger8 = db.enFazlaKitap().FirstOrDefault();
            var deger9 = db.TBLKITAP.GroupBy(x => x.YAYINEVI).OrderByDescending(y => y.Count()).Select(z => new { z.Key }).FirstOrDefault();
            var deger10 = db.enbasariliPersonelTWO().FirstOrDefault();
            var deger11 = db.tbl_iletisim.Count();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr6 = deger6;
            ViewBag.dgr7 = deger7;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr10 = deger10;
            ViewBag.dgr11 = deger11;
            return View();
        }
    }
}