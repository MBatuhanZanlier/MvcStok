using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {   
            var degerler = db.TBLKATEGORI.ToList().ToPagedList(sayfa, 2);
            //var degerler = db.TBLKATEGORI.ToList();
            return View(degerler);
        }

        [HttpGet] 
        public  ActionResult YeniKategori()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI p)
        { 
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return View(); 
        } 
        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
        public ActionResult Güncelle(int id)
        {
            var ktgr = db.TBLKATEGORI.Find(id);
            return View("Güncelle",ktgr);
        } 

        public ActionResult GüncelleIki(TBLKATEGORI p) 
        {
            var ktg = db.TBLKATEGORI.Find(p.KATEGORIID);
            ktg.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}