namespace Softw2Aufgabe.Api
{
    public class Movie
    {
        public String Name { get; set; }
        public int Id { get; set; }

        public Movie(String name)
        {
            Name = name;
            Id = Data.GetMovies().Count;
        }

    }
}
