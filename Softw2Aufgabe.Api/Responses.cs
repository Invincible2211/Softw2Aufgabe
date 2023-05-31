namespace Softw2Aufgabe.Api.Responses
{
    public class MovieResponse
    {
        public List<Movie> Movies { get; set; }
    }

    public class SaveMovieResponse
    {
        public Guid Id { get; set; }
    }
}
