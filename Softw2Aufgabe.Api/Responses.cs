namespace Softw2Aufgabe.Api.Responses
{
    public class MovieResponse
    {
        public List<Movie> Movies { get; set; }
    }

    public class SaveMovieResponse
    {
        public int Id { get; set; }
    }

    public class SearchMovieResponse
    {
        public Movie Movie { get; set; }
    }

    public class SearchMovieNameResponse
    {
        public List<Movie> Movies { get; set; }
    }

}
