using System;
using System.Linq;
using MovieDataBase_Domain;
using MovieDataBase_DTO;

namespace MovieDataBaseConsole
{

    public class MovieObject
    {
        MovieInteractor _movieInteractor = new MovieInteractor();

        public List<Movie> BuildMovieCollection()
        {
            List<Movie> initialMovies = new List<Movie>();
            initialMovies.Add(new Movie() { Title = "Step Brothers", Genre = "Comedy", RunTime = 98 });
            initialMovies.Add(new Movie() { Title = "The Fast and the Furious", Genre = "Action", RunTime = 108 });
            initialMovies.Add(new Movie() { Title = "2 Fast 2 Furious", Genre = "Action", RunTime = 108 });
            initialMovies.Add(new Movie() { Title = "The Fast and the Furious :Tokyo Drift", Genre = "Action", RunTime = 104 });
            initialMovies.Add(new Movie() { Title = "Dispicable Me", Genre = "Kid", RunTime = 95 });
            initialMovies.Add(new Movie() { Title = "IT", Genre = "Horror", RunTime = 135 });
            initialMovies.Add(new Movie() { Title = "21 Jumpstreet", Genre = "Comedy", RunTime = 109 });
            initialMovies.Add(new Movie() { Title = "Remember the Titans", Genre = "Drama", RunTime = 120 });
            initialMovies.Add(new Movie() { Title = "The Tinder Swindler", Genre = "Documentary", RunTime = 114 });
            initialMovies.Add(new Movie() { Title = "Free Solo", Genre = "Documentary", RunTime = 100 });
            initialMovies.Add(new Movie() { Title = "Alexander The Great", Genre = "Drama", RunTime = 175 });
            initialMovies.Add(new Movie() { Title = "The Conjuring", Genre = "Horror", RunTime = 112 });
            return initialMovies;
        }


        public void LoadStartUpData()
        {
            foreach (Movie movie in BuildMovieCollection())
            {
                if (_movieInteractor.AddNewMovie(movie) == true)
                {
                    Console.WriteLine($"{movie.Title} was added to the database.");
                }
                else
                {
                    Console.WriteLine($"{movie.Title} was NOT added to the database.");
                }
            }
        }

        public void DisplayAllMovies()
        {
            Console.WriteLine();
            Console.WriteLine("The following Movies are in the database");
            foreach (Movie movie in _movieInteractor.GetAllMovies())
            {
                Console.WriteLine($" - {movie.Title}, {movie.Genre}, {movie.RunTime}mins");
            }
        }
        public void SearchMovieByTitle(string movieTitle)
        {
            Console.WriteLine();
            Console.WriteLine($"Searching for Movie {movieTitle}");
            bool movieExist = _movieInteractor.GetMovieIfExists(movieTitle, out Movie returnedMovie);
            if (movieExist)
            {
                Console.WriteLine($"{movieTitle} is in the collection");
                Console.WriteLine($"{returnedMovie.Title}: {returnedMovie.Genre}: {returnedMovie.RunTime} mins"); }
            else
            { Console.WriteLine($"{movieTitle} does not exist in this collection"); }
        }
        public void SearchMovieByGenre(string movieGenre)
        {
            Console.WriteLine();
            Console.WriteLine($"Searching for Genre {movieGenre}");
            bool genreExist = _movieInteractor.GetGenreIfExists(movieGenre, out List<Movie> returnedGenre);
            if (genreExist)
            {
                string moreThanOne = returnedGenre.Count() > 1 ? "Movies" : "Movie";
                string areIs = returnedGenre.Count() > 1 ? "are" : "is";
                Console.WriteLine($"There {areIs} {returnedGenre.Count()} {movieGenre} {moreThanOne} in the collection");
                foreach (Movie movie in returnedGenre)
                {
                    Console.WriteLine($"{movie.Title}: {movie.Genre}: {movie.RunTime} mins");
                }
            }
            else
            { Console.WriteLine($"{movieGenre} does not exist in this Collection"); }
        }

 
    }

}

