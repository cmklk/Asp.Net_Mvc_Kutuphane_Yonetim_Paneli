using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Login
        public ActionResult girisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult girisYap(TBL_UYE p)
        {
            var kullaniciBilgi = db.TBL_UYE.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (kullaniciBilgi != null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciBilgi.MAIL, false);
                Session["MAIL"] = kullaniciBilgi.MAIL.ToString();
                //TempData["ID"] = kullaniciBilgi.ID.ToString();
                //TempData["AD"] = kullaniciBilgi.AD.ToString();
                //TempData["SOYAD"] = kullaniciBilgi.SOYAD.ToString();
                //TempData["KULLANICIADI"] = kullaniciBilgi.KULLANICIADI.ToString();
                //TempData["SIFRE"] = kullaniciBilgi.SIFRE.ToString();
                //TempData["OKUL"] = kullaniciBilgi.OKUL.ToString();
                return RedirectToAction("Index", "ogrenciPanel");
            }
            else
            {
                return View();
            }
        }
    }
}