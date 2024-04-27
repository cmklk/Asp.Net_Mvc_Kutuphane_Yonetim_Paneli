using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class islemlerController : Controller
    {
        // GET: islemler
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var islemList = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();

            return View(islemList);
        }
    }
}