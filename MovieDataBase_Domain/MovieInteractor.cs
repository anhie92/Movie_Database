using MovieDataBase_DTO;
using MovieDataBaseRepository;
namespace MovieDataBase_Domain;

public class MovieInteractor
{
    private MovieRepository _respository;

    public MovieInteractor()
    {
        _respository = new MovieRepository();
    }


    public bool AddNewMovie(Movie movieToAdd)
    {
        if (string.IsNullOrEmpty(movieToAdd.Title) || string.IsNullOrEmpty(movieToAdd.Genre))
        {
            throw new ArgumentException("Title and Genre must contain valid text.");
        }
        return _respository.AddMovie(movieToAdd);
    }

    public List<Movie> GetAllMovies()
    {
        return _respository.GetAllMovies();
    }

    public bool GetMovieIfExists(string movieTitle, out Movie movieToReturn)
    {
        Movie movie = _respository.GetMovieByTitle(movieTitle);
        movieToReturn = movie;
        return movieToReturn != null;
    }

    public bool GetGenreIfExists(string movieGenre, out List<Movie> genreToReturn)
    {
        List<Movie> genre = _respository.GetMovieGenre(movieGenre);
        genreToReturn = genre;
        return genreToReturn != null;
    }




}

