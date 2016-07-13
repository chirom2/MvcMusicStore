using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcMusicStore.Models
{
    public class SampleData2 : DropCreateDatabaseAlways<MusicStoreEntities>
    {

        protected override void Seed(MusicStoreEntities context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Rock" },
                new Genre { Name = "Jazz" },

            };

            var artists = new List<Artist>
            {
                new Artist { Name = "Aaron Copland & London Symphony Orchestra" },
                new Artist { Name = "Aaron Goldberg" }

            };

            new List<Album>
            {
                new Album { Title = "The Best Of Men At Work", Genre = genres.Single(g => g.Name == "Rock"), Price = 8.99M, Artist = artists.Single(a => a.Name == "Aaron Goldberg"), AlbumArtUrl = "" } ,
            }.ForEach(a => context.Albums.Add(a));
        }
    }
}