using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVC.Models
{
    public class Movie
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Amount in stock")]
        public int noInStock { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? dateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }

        [ForeignKey("genreId")]
        public Genre genre { get; set; }

        [Display(Name = "Genre")]
        public int genreId { get; set; }
    }
}