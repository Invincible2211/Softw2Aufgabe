namespace Softw2Aufgabe.Api
{
    public class Movie
    {
        public String Name { get; set; }
        public Guid Id { get; set; }

        public Movie(String name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

    }
}
