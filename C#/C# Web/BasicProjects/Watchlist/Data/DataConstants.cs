namespace Watchlist.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int MinUserUsername = 5;
            public const int MaxUserUsername = 20;

            public const int MinUserEmail = 10;
            public const int MaxUserEmail = 60;

            public const int MinUserPassword = 5;
            public const int MaxUserPassword = 20;
        }

        public class Movie
        {
            public const int MinMovieTitle = 10;
            public const int MaxMovieTitle = 50;
                                
            public const int MinMovieDirector = 5;
            public const int MaxMovieDirector = 50;
                                
            public const double MinMovieRating = 0.0;
            public const double MaxMovieRating = 10.00;
        }

        public class Genre
        {
            public const int MinGenreName = 5;
            public const int MaxGenreName = 50;
        }
    }
}
