using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.ViewModels
{
    public class EditVM
    {
        public int id { get; set; }

        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Artist")]
        public string artist { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100, ErrorMessage = "Price must be between 0.01 and 1")]
        public decimal price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string albumArtUrl { get; set; }

        public int GenreId { get; set; }
        public int ArtistId { get; set; }

        [DisplayName("Genres")]
        public SelectList GenreList { get; set; }
        [DisplayName("Artists")]
        public SelectList ArtistList { get; set; }

    }
}