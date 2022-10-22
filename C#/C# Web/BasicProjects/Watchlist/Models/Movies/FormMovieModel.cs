namespace Watchlist.Models.Movies
{
    using System.ComponentModel.DataAnnotations;
    using static Watchlist.Data.DataConstants.Movie;

    public class FormMovieModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxMovieTitle,
            MinimumLength = MinMovieTitle,
            ErrorMessage = "{0} length must be between {2} and {1}.")]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxMovieDirector,
            MinimumLength = MinMovieDirector,
            ErrorMessage = "{0} length must be between {2} and {1}.")]
        public string Director { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Range(0.0, 10.0,
            ErrorMessage = "{0} must be between {2} and {1}.")]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public List<MovieGenerViewModel>? Genres { get; set; }
    }
}
