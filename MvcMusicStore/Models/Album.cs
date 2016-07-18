using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    [Bind(Exclude = "AlbumId")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }//N'est pas géré par la structure, pas de proposition de saisi ds les form
        
        [Required(ErrorMessage="An album name is required")]
        public string Title { get; set; }

        [DisplayName("Genre")]
        public int GenreId { get; set; }
        
        [DisplayName("Artist")]
        public int ArtistId { get; set; }
        
        [Required(ErrorMessage="Price is required")]
        [Range(0.01, 100, ErrorMessage = "Price must be between 0.01 and 1")]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

    }
}