using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        //Navigation Properties

       [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie"; 

            }

        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}