using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace MovieStoreSerializationClassLibrary.Service
{

    public class MovieManager
    {
        public const string filePath = @"C:\Users\Adithya AV\OneDrive\Desktop\assignment\movies.txt";

        private List<Movie> movies;

        public MovieManager()
        {
            movies = new List<Movie>();
            LoadMovies(); 
        }

        public string DisplayMovies()
        {
            if (movies.Count == 0)
            {
                throw new MovieStoreEmptyException("The store is empty. Movie store empty exception.");
            }

            StringBuilder output = new StringBuilder("Movies in the store:\n");
            foreach (Movie movie in movies)
            {
                output.AppendLine($"-->Movie Id: {movie.Id}\nName: {movie.Title}\nGenre: {movie.Genre}\nYear: {movie.Year}\n=======");
            }
            return output.ToString();
        }

        public string AddMovie(int id, string title, int year, string genre)
        {
            if (movies.Count < Movie.MOVIE_COUNT)
            {
                Movie movieToAdd = new Movie(id, title, year, genre);
                movies.Add(movieToAdd);

               
                SaveMovies();

                return "Movie added successfully.";
            }
            else
            {
                throw new MovieStoreFullException("Cannot add more than five movies. Movie store is full.");
            }
        }

        public string ClearAll()
        {
            movies.Clear();

           
            SaveMovies();

            return "All movies cleared from the list";
        }
        public string FindMovieByYear(int year)
        {

            var moviesByYear = movies.FindAll(movie => movie.Year == year);

            if (moviesByYear.Count > 0)
            {
                StringBuilder output = new StringBuilder($"Movies released in {year}:\n");
                foreach (Movie movie in moviesByYear)
                {
                    output.AppendLine($"-->Movie Id:{movie.Id}\nName:{movie.Title}\nGenre:{movie.Genre}\nYear: {movie.Year}\n=======");
                }
                return output.ToString();
            }

            return $"No movies found for the year {year}.";
        }
       
        public string RemoveMovieByName(string nameToRemove)
        {
            movies.RemoveAll(movie => movie.Title.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase));
            return $"Movie '{nameToRemove}' removed.";
        }



        private void SaveMovies()
        {
            DataSerializer.BinarySerializer(filePath, movies);
        }

        private void LoadMovies()
        {
            movies = DataSerializer.BinaryDeserializer(filePath);
        }
    }
}


