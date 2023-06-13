using Softw2Aufgabe.Api.Responses;

namespace Softw2Aufgabe.Api;

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

    public static bool RemoveMovie(int id)
    {
        foreach (var movie in movies)
        {
            if (movie.Id == id)
            {
                movies.Remove(movie);
                return true;
            }
        }
        return false;
    }

}
