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

}
