namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Genre;
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxGenreName,
            MinimumLength = MinGenreName)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
            = new List<Movie>();
    }
}
