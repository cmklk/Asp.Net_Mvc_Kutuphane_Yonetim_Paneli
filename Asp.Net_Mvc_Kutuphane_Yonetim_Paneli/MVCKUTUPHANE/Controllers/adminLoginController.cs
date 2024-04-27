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
    public class adminLoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();


        // GET: adminLogin

             [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(tbl_admin p)
        {
            var adminBilgi = db.tbl_admin.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.ŞİFRE == p.ŞİFRE);

            if(adminBilgi != null)
            {
                FormsAuthentication.SetAuthCookie(adminBilgi.KULLANICIADI, false);
                Session["Kullanici"] = adminBilgi.KULLANICIADI.ToString();
                return RedirectToAction("Index", "kategori");
            }

            else
            {
                return View();
            }
         
        }


        public ActionResult adminCikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("girisYap","Login");
        }
    }
}