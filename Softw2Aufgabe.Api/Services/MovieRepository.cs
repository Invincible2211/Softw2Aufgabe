using FastEndpoints;

namespace Softw2Aufgabe.Api.Services;

public interface IMovieRepository
{
    int Add(Movie movie);
    IEnumerable<Movie> GetAll();
    bool Remove(int id);
    Movie? GetById(int id);
}

public sealed class MovieRepository : IMovieRepository
{
    private readonly List<Movie> movies = new();

    public int Add(Movie movie)
    {
        movie.Id = movies.Count;
        movies.Add(movie);
        return movie.Id;
    }

    public IEnumerable<Movie> GetAll()
    {
        return movies;
    }

    public Movie? GetById(int id)
    {
        return movies.Find(x => x.Id == id);
    }

    public bool Remove(int id)
    {
        var movie = movies.Find(x => x.Id == id);
        if (movie is null)
            return false;

        movies.Remove(movie);
        return true;
    }
}
