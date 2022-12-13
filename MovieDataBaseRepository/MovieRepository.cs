using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MovieDataBase_DTO;


namespace MovieDataBaseRepository
{
    public class MovieRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;

        public MovieRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieDataBase"));
        }


        public bool AddMovie(Movie movieToAdd)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                
                Movie existingItem = db.Movies.FirstOrDefault(x => x.Title.ToLower() == movieToAdd.Title.ToLower());

                if (existingItem == null)
                {
                    db.Movies.Add(movieToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<Movie> GetAllMovies()
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                
                return db.Movies.ToList();
            }
        }

        public Movie GetMovieByTitle(String movieTitle)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.FirstOrDefault(x => x.Title == movieTitle);
            }
        }

        public List<Movie> GetMovieGenre(String movieGenre)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.Where(x => x.Genre == movieGenre).ToList();
            }
        }



    }
}
