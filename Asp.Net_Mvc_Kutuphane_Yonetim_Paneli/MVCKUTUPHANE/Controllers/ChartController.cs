using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.siniflar;
namespace MVCKUTUPHANE.Controllers
{
    public class ChartController : Controller
    {

       
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizeBookResult()
        {
            return Json(liste());
        }

        public List<Class2> liste()
        {
            List<Class2> cs2 = new List<Class2>();
            cs2.Add(new Class2()
            {
                yayinEvi = "Güneş YayınEvi",
                sayi=7
            });

            cs2.Add(new Class2()
            {
                yayinEvi ="Satürn YayınEvi",
                sayi =10
            });

            cs2.Add(new Class2()
            {
                yayinEvi = "Mars YayınEvi",
                sayi = 12
            });
            return cs2;

        }
    }
}