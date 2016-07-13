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
        //GET /StoreManager/Edit
        public ActionResult Edit(int id = 0)
        {
            using (var db = new MusicStoreEntities())
            {
                var album = db.Albums.Include(a => a.Genre).Include(a => a.Artist).Single(a => a.AlbumId == id);
                var genres = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
                var artists = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
                ViewBag.genres = genres;
                ViewBag.artists = artists;
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
        public ActionResult Delete(int id = 0)
        {
            using (var db = new MusicStoreEntities())
            {
                var album = db.Albums.Include(a => a.Genre).Include(a => a.Artist).Single(a => a.AlbumId == id);
                return View(album);
            }
        }

    }
}
