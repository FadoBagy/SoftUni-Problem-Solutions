namespace Watchlist.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants.Movie;

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxMovieTitle, 
            MinimumLength = MinMovieTitle)]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxMovieDirector,
            MinimumLength = MinMovieDirector)]
        public string Director { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Range(0.0, 10.0)]
        [Column(TypeName = "decimal(10,1)")]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<UserMovie> UsersMovies { get; set; }
            = new List<UserMovie>();
    }
}
