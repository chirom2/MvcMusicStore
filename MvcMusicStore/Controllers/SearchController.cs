using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DisplayResult(String searchString)
        {
            using (var db = new MusicStoreEntities())
            {
                var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist).Where(
                    a => a.Title.Contains(searchString) ||
                    a.Artist.Name.Contains(searchString) ||
                    a.Genre.Name.Contains(searchString)
                    ).ToList();
                return PartialView(albums);
            }        
        }
    }
}
