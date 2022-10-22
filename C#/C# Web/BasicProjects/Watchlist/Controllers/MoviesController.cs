using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models.Movies;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly WatchlistDbContext data;
        public MoviesController(WatchlistDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var movies = data.Movies
                .Select(m => new ViewMovieModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    Rating = (float)m.Rating,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name
                })
                .ToList();

            return View(movies);
        }

        public IActionResult Watched() 
        {
            var movies = data.UsersMovies
                .Where(um => um.UserId == GetCurrentUserId())
                .Select(um => new ViewMovieModel()
                {
                    Id = um.Movie.Id,
                    Title = um.Movie.Title,
                    Director = um.Movie.Director,
                    Rating = (float)um.Movie.Rating,
                    ImageUrl = um.Movie.ImageUrl,
                    Genre = um.Movie.Genre.Name,
                })
                .ToList();

            return View(movies);
        }

        public IActionResult Add()
        {
            return View(new FormMovieModel
            {
                Genres = GetGeners()
            });
        }

        [HttpPost]
        public IActionResult Add(FormMovieModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new FormMovieModel
                {
                    Title = model.Title,
                    Director = model.Director,
                    ImageUrl = model.ImageUrl,
                    Rating = model.Rating,
                    GenreId = model.GenreId,
                    Genres = GetGeners()
                });
            }

            var newMovie = new Movie
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = (decimal)model.Rating,
                GenreId = model.GenreId
            };
            data.Movies.Add(newMovie);

            data.SaveChanges();

            return RedirectToAction("All", "Movies");
        }

        public IActionResult AddToCollection(int movieId)
        {
            var movies = data.UsersMovies
                .Where(um => um.MovieId == movieId)
                .ToList();

            var currentUser = data.Users
                .FirstOrDefault(u => u.Id == GetCurrentUserId());

            if (!movies.Any(m => m.UserId == GetCurrentUserId()))
            {
                currentUser?.UsersMovies.Add(new UserMovie
                {
                    UserId = GetCurrentUserId(),
                    MovieId = movieId
                });
            }

            data.SaveChanges();

            return RedirectToAction("All", "Movies");
        }

        public IActionResult RemoveFromCollection(int movieId)
        {
            var usersMovies = data.UsersMovies
                .FirstOrDefault(um => um.MovieId == movieId);

            var currentUser = data.Users
                .FirstOrDefault(u => u.Id == GetCurrentUserId());

            if (usersMovies != null)
            {
                currentUser?.UsersMovies.Remove(usersMovies);
            }

            data.SaveChanges();

            return RedirectToAction("Watched", "Movies");
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private List<MovieGenerViewModel> GetGeners()
        {
            return data.Genres
                .Select(g => new MovieGenerViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();
        }
    }
}
