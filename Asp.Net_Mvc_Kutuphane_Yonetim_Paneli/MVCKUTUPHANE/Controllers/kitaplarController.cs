using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
namespace MVCKUTUPHANE.Controllers
{
    public class kitaplarController : Controller
    {
        // GET: kitaplar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));
            }


            return View(kitaplar.ToList());
        }
        //var bookList = db.TBLKITAP.ToList();
        //  return View(bookList);
    

        [HttpGet]
        public ActionResult kitapEkle()
        {
            List<SelectListItem> kategeriDeger = (from x in db.TBLKATEGORI.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.AD,
                                                      Value = x.ID.ToString()
                                                  }).ToList();
            ViewBag.dgr1 = kategeriDeger;



            List<SelectListItem> yazarDeger = (from y in db.TBL_YAZAR.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = y.AD +" "+y.SOYAD,
                                                   Value = y.ID.ToString()
                                               }).ToList();
            ViewBag.dgr2 = yazarDeger;
            return View();
        }

        [HttpPost]
        public ActionResult kitapEkle(TBLKITAP p)
        {
            var ktgr = db.TBLKATEGORI.Where(x => x.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yazar = db.TBL_YAZAR.Where(y => y.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            p.TBLKATEGORI = ktgr;
            p.TBL_YAZAR = yazar;
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KitapSil (int id)
        {
            var findBook = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(findBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kitapVeriGetir(int id)
        {
            var veriler = db.TBLKITAP.Find(id);

            List<SelectListItem> yazarDegerler = (from x in db.TBL_YAZAR.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.AD +" "+x.SOYAD,
                                                      Value = x.ID.ToString()
                                                  }).ToList();
            ViewBag.dgr1 = yazarDegerler;


            List<SelectListItem> kategoriDeger = (from x in db.TBLKATEGORI.ToList() select new SelectListItem
            {
                Text = x.AD,
                Value = x.ID.ToString()
            }).ToList();

            ViewBag.dgr2 = kategoriDeger;
            return View("kitapVeriGetir",veriler);
        }


        public ActionResult kitapGuncelle (TBLKITAP p)
        {
            var kitap = db.TBLKITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYILI = p.BASIMYILI;
            kitap.SAYFA = p.SAYFA;
            kitap.DURUM = true;
            kitap.YAYINEVI = p.YAYINEVI;
            var ktgr = db.TBLKATEGORI.Where(x => x.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yazar = db.TBL_YAZAR.Where(x => x.ID == p.TBL_YAZAR.ID).FirstOrDefault();

            kitap.KATEGORI = ktgr.ID;
            kitap.YAZAR = yazar.ID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}