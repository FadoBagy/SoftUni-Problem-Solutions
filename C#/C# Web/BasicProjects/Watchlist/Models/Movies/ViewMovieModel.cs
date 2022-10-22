namespace Watchlist.Models.Movies
{
    using Watchlist.Data.Models;

    public class ViewMovieModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        public float Rating { get; set; }

        public string Genre { get; set; }
    }
}
