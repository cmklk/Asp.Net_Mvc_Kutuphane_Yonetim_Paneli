using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    [AllowAnonymous]
    public class registerController : Controller
    {
        DBKUTUPHANEEntities db =new DBKUTUPHANEEntities();
        // GET: register

        [HttpGet]
        public ActionResult kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult kayit(TBL_UYE p)
        {
            db.TBL_UYE.Add(p);
            db.SaveChanges();
            return View("kayit");
        }
    }
}