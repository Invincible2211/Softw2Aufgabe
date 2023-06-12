namespace Softw2Aufgabe.Api.Requests
{
    public class MovieRequest
    {
    }

    public class SaveMovieRequest
    {
        public String Name { get; set; }
    }

    public class SearchMovieRequest
    {
        public int Id { get; set; }
    }

    public class SearchMovieNameRequest
    {
        public String Name { get; set; }
    }

}
