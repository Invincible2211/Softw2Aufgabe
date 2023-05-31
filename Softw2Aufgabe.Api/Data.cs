namespace Softw2Aufgabe.Api
{
    public class Data
    {
        private static readonly List<Movie> movies = new(new Movie[]{
        new Movie("Test1"),
        new Movie("Test2"),
        new Movie("Test3")
        });

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
