using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class MesajlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Mesajlar
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Mesajlar()
        {
            var uyeMail = (string)Session["MAIL"].ToString();
            var bilgiler = db.TBL_MESAJLAR.Where(x=>x.ALICI==uyeMail.ToString()).ToList();
            return View(bilgiler);
        }


        public ActionResult gonderilenMesaj()
        {
            var uyeMail = (string)Session["MAIL"].ToString();
            var gonderilen = db.TBL_MESAJLAR.Where(x => x.GONDEREN == uyeMail.ToString()).ToList();
            return View(gonderilen);
        }

        [HttpGet]
        public ActionResult yeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniMesaj(TBL_MESAJLAR t)
        {
            var uyeMail = (string)Session["MAIL"].ToString();
            t.GONDEREN = uyeMail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_MESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("gonderilenMesaj", "Mesajlar");
        }



        public PartialViewResult partial1()
        {

            var uyeMail = (string)Session["MAIL"].ToString();
            var gonderen = db.TBL_MESAJLAR.Where(x => x.GONDEREN == uyeMail).Count();
            ViewBag.dgr1 = gonderen;

            var gelen = db.TBL_MESAJLAR.Where(x => x.ALICI == uyeMail).Count();
            ViewBag.dgr2 = gelen;
            return PartialView();
        }
    }
}