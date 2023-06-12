using Microsoft.AspNetCore.Http.HttpResults;
using Softw2Aufgabe.Api.Requests;
using Softw2Aufgabe.Api.Responses;

namespace Softw2Aufgabe.Api.Endpoints
{
    public sealed class MovieEndpoint : Endpoint<MovieRequest, MovieResponse>
    {
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("movies");
            AllowAnonymous();
        }

        public override async Task HandleAsync(MovieRequest req, CancellationToken ct)
        {
            var response = new MovieResponse()
            {
                Movies = Data.GetMovies()
            };
            await SendAsync(response, cancellation: ct);
        }
    }

    public class SaveMovieEndpoint : Endpoint<SaveMovieRequest, SaveMovieResponse>
    {
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("movies");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SaveMovieRequest req, CancellationToken ct)
        {
            Movie movie = new(req.Name);
            Data.AddMovie(movie);
            var response = new SaveMovieResponse()
            {
                Id = movie.Id
            };
            await SendAsync(response, 201, cancellation: ct);
        }
    }

    public class SearchMovieEndpoint : Endpoint<SearchMovieRequest, SearchMovieResponse>
    {
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("movies/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SearchMovieRequest req, CancellationToken ct)
        {
            foreach (var movie in Data.GetMovies())
            {
                if (movie.Id == req.Id)
                {
                    var response = new SearchMovieResponse()
                    {
                        Movie = movie
                    };
                    await SendAsync(response, cancellation: ct);
                    return;
                }
            }
            await SendNotFoundAsync(ct);
        }
    }

}
