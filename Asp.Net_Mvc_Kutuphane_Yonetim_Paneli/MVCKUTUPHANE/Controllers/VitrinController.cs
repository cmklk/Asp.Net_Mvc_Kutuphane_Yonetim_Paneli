using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
using MVCKUTUPHANE.Models.siniflar;
namespace MVCKUTUPHANE.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
       
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Vitrin
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Vitrin()
        {
            Class1 css = new Class1();
            css.deger1 = db.TBLKITAP.ToList();
            css.deger2 = db.tbl_aciklama.ToList();
            return View(css);
        }

        [HttpPost]
        public ActionResult Vitrin(tbl_iletisim t)
        {
            db.tbl_iletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Vitrin");
        }
    }
}