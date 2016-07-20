using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;

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
            using (var db = new MusicStoreEntities())
            {
                var items = db.Genres.Select(g => new
                {
                    Value = g.GenreId,
                    Text = g.Name
                });

                var itemsArtist = db.Artists.Select(a => new
                {
                    Value = a.ArtistId,
                    Text = a.Name
                });

                var listGenres = new SelectList(items.ToList(), "Value", "Text");
                var listArtist = new SelectList(itemsArtist.ToList(), "Value", "Text");
                var createVM = new CreateVM();
                createVM.ArtistList = listArtist;
                createVM.GenreList = listGenres;

                return View(createVM);
            }
        }

        //
        //POST : /StoreManager/Create
        [HttpPost]
        public ActionResult Create(CreateVM vm)
        {
            using (var db = new MusicStoreEntities())
            {
                if (ModelState.IsValid)
                {
                    var album = new Album
                    {
                        ArtistId = vm.ArtistId,
                        GenreId = vm.GenreId,
                        Title = vm.title,
                        Price = vm.price,
                        AlbumArtUrl = vm.albumArtUrl
                    };

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
                var album = db.Albums.Include(a => a.Genre).Include(a => a.Artist)
                    .Single(a => a.AlbumId == id);

                var itemsGenres = db.Genres.Select(g => new {Value = g.GenreId, Text = g.Name});
                
                var itemsArtist = db.Artists.Select(a => 
                    new { Value = a.ArtistId,Text = a.Name });

                var editVm = new EditVM
                {
                    id = album.AlbumId,
                    title = album.Title,
                    ArtistId = album.ArtistId,
                    GenreId = album.GenreId,
                    price = album.Price,
                    albumArtUrl = album.AlbumArtUrl,
                    GenreList = new SelectList(itemsGenres.ToList(), "Value", "Text"),
                    ArtistList = new SelectList(itemsArtist.ToList(), "Value", "Text")
                };

                return View(editVm);
            }
        }

        //
        //POST: /StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(EditVM vm)
        {
            using (var db = new MusicStoreEntities())
            {
                    if (ModelState.IsValid)
                    {
                        var album = db.Albums.Single(a => a.AlbumId == vm.id);
                        album.AlbumId = vm.id;
                        album.ArtistId = vm.ArtistId;
                        album.GenreId = vm.GenreId;
                        album.Title = vm.title;
                        album.Price = vm.price;
                        album.AlbumArtUrl = vm.albumArtUrl;
                        db.Entry(album).State = EntityState.Modified;
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