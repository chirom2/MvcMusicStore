using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.Controllers
{
    public class LinqExamplesController : Controller
    {
        //
        // GET: /LinqExamples/

        public ActionResult Index()
        {
            return View();
        }

        //
        //GET: /LinqExamples/select

        public ActionResult Select()
        {
            using (var db = new MusicStoreEntities())
            {
                //var select = db.Albums.ToList();
                var select = db.Albums.Where(a => a.Title.Contains("z"));
                return View(select.ToList());
            }
        }

        //
        //GET: /LinqExamples/Any

        public ActionResult Any()
        {
            using (var db = new MusicStoreEntities())
            {
                var any = db.Albums.Any(a => a.Title.Contains("z"));
                ViewData["Any"] = any;
                return View();
            }
        }

        //
        //GET: /LinqExamples/Count

        public ActionResult Count()
        {
            using (var db = new MusicStoreEntities())
            {
                var countVm = new CountVm
                {
                    CountAlbum = db.Albums.Count(),
                    CountGenre = db.Genres.Count(),
                    CountArtist = db.Artists.Count()
                };
                return View(countVm);
            }
        }


        //
        //GET: /LinqExamples/SelectMany

        public ActionResult SelectMany()
        {
            using (var db = new MusicStoreEntities())
            {

                return View();
            }
        }
    }
}