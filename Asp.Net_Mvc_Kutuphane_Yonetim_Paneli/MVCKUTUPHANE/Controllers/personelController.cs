using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class personelController : Controller
    {
        // GET: personel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            // var personelList = db.TBLPERSONEL.ToList();

            var personelList = from k in db.TBLPERSONEL select k;
            if (!string.IsNullOrEmpty(p))
            {
                personelList = personelList.Where(x => x.PERSONEL.Contains(p));
            }
            return View(personelList.ToList());
        }

        [HttpGet]
        public ActionResult personelEkle()
        {
            return View();
        }



        [HttpPost]
        public ActionResult personelEkle(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("personelEkle");
            }

            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult personelSil(int id)
        {
            var findPers = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(findPers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult personelVeriGetir (int id)
        {
            var personelFind = db.TBLPERSONEL.Find(id);
            return View("personelVeriGetir",personelFind);
        }


        public ActionResult personelGuncelle (TBLPERSONEL p)
        {
            var guncelle = db.TBLPERSONEL.Find(p.ID);
            guncelle.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}