using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            using (var db = new MusicStoreEntities())
            {
                var genres = db.Genres.ToList();
                return View(genres);
            }
        }


        //
        //GET : /Store/Browse?genre=Disco

        public ActionResult Browse(string genre="")
        {

            using (var db = new MusicStoreEntities())
            {
                var genreModel = db.Genres.Include("Albums").Single(g => g.Name == genre);
                return View(genreModel);
            }

        }


        //
        //GET : /Store/Details/5

        public ActionResult Details(int id = 0)
        {
            using (var db = new MusicStoreEntities())
            {
                var album = db.Albums.Find(id);
                return View(album);
            }
        }

    }
}
