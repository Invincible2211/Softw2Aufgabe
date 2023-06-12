namespace Softw2Aufgabe.Api
{
    public class Data
    {
        private static readonly List<Movie> movies = new();

        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public static List<Movie> GetMovies() 
        { 
            return movies; 
        }

    }
}
