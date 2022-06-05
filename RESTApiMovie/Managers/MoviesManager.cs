using MovieDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApiMovie.Managers
{
    public class MoviesManager
    {
        private static int _nextID = 1;

        private static List<Movie> _movies = new List<Movie>()
        {
            new Movie() { Id = _nextID++, Name = "Harry Potter", Country = "America", LengthInMinutes = 152 },
            new Movie() { Id = _nextID++, Name = "Lord og the Rings", Country = "New Zealand" , LengthInMinutes = 178 },
            new Movie() { Id = _nextID++, Name = "Hobitten", Country = "America", LengthInMinutes = 169 }
        };

        public IEnumerable<Movie> GetAll()
        {
            List<Movie> result = new List<Movie>(_movies);
            return result;
        }

        public Movie GetById(int id)
        {
            if (id == null)
            {
                return null;
            }
            Movie movie = _movies.Find(m => m.Id == id);
            return movie;
        }

        public Movie AddMovie(Movie newMovie)
        {
            if (newMovie == null)
            {
                return null;
            }
            newMovie.Id = _nextID++;
            _movies.Add(newMovie);
            return newMovie;
        }
    }
}
