using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class adminAyarlarController : Controller
    {

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: adminAyarlar
        public ActionResult Index()
        {
            var admins = db.tbl_admin.ToList();
            return View(admins);
        }


        [HttpGet]
        public ActionResult yeniAdmin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult yeniAdmin(tbl_admin p)
        {
            db.tbl_admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult adminSil(int id)
        {
            var admin = db.tbl_admin.Find(id);
            db.tbl_admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult adminBilgiGetir(int id)
        {
            var bilgiler = db.tbl_admin.Find(id);
            return View("adminBilgiGetir",bilgiler);
        }


        public ActionResult adminGuncelle(tbl_admin p)
        {
            var admin = db.tbl_admin.Find(p.ID);
            admin.KULLANICIADI = p.KULLANICIADI;
            admin.ŞİFRE = p.ŞİFRE;
            admin.YETKİ = p.YETKİ;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}