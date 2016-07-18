using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        //
        // GET: /StoreManager/

        public ActionResult Index()
        {
            using (var db = new MusicStoreEntities())
            {
                var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);
                return View(albums.ToList());
            }
        }


        //
        //GET : /StoreManager/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        //POST : /StoreManager/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            using (var db = new MusicStoreEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Albums.Add(album);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();   
                }                
            }
        }
        
        
        //
        //GET /StoreManager/Edit/5
        public ActionResult Edit(int id = 0)
        {
            using (var db = new MusicStoreEntities())
            {
                var album = db.Albums.Include(a => a.Genre).Include(a => a.Artist).Single(a => a.AlbumId == id);
                return View(album);
            }
        }

        //
        //POST: /StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            using (var db = new MusicStoreEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(album).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(album);
            }            
        }

        //
        //GET /StoreManager/Details

        public ActionResult Details(int id = 0)
        {
            using (var db = new MusicStoreEntities())
            {
                var album = db.Albums.Include(a => a.Genre).Include(a => a.Artist).Single(a => a.AlbumId == id);
                //var album = db.Albums.Find(id);
                return View(album);

            }

        }

        //
        //GET /StoreManager/Delete

        public ActionResult Delete(int id)
        {
            using (var db = new MusicStoreEntities())
            {
                Album album = db.Albums.Find(id);
                return View(album);
            }
            
        }

        //
        //POST /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new MusicStoreEntities())
            {
                Album album = db.Albums.Find(id);
                db.Albums.Remove(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
