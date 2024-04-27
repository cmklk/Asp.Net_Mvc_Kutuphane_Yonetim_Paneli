using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class ogrenciDuyuruController : Controller
    {
        // GET: ogrenciDuyuru
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var ogrenciDuyuru = db.tbl_duyurular.ToList();
            return View(ogrenciDuyuru);
        }
    }
}