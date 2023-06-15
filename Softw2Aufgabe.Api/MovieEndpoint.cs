using Softw2Aufgabe.Api.Requests;
using Softw2Aufgabe.Api.Responses;
using Softw2Aufgabe.Api.Services;
using System.Net;

namespace Softw2Aufgabe.Api.Endpoints;

public sealed class MovieEndpoint : Endpoint<MovieRequest, MovieResponse>
{
    private readonly IMovieRepository _movieRepository;

    public MovieEndpoint(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public override void Configure()
    {
        Get("movies");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MovieRequest req, CancellationToken ct)
    {
        var response = new MovieResponse()
        {
            Movies = _movieRepository.GetAll()
        };
        await SendAsync(response, cancellation: ct);
    }
}

public class SaveMovieEndpoint : Endpoint<SaveMovieRequest, SaveMovieResponse>
{
    private readonly IMovieRepository _movieRepository;

    public SaveMovieEndpoint(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public override void Configure()
    {
        Post("movies");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SaveMovieRequest req, CancellationToken ct)
    {
        var movie = new Movie
        {
            Name = req.Name
        };
        var response = new SaveMovieResponse()
        {
            Id = _movieRepository.Add(movie)
        };
        await SendAsync(response, (int)HttpStatusCode.Created, ct);
    }
}

public class SearchMovieEndpoint : Endpoint<SearchMovieRequest, SearchMovieResponse>
{
    private readonly IMovieRepository _movieRepository;

    public SearchMovieEndpoint(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public override void Configure()
    {
        Get("movies/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchMovieRequest req, CancellationToken ct)
    {
        var movie = _movieRepository.GetById(req.Id);
        if (movie is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        var response = new SearchMovieResponse
        {
            Movie = movie
        };
        await SendAsync(response, cancellation: ct);
    }
}

public class SearchMovieNameEndpoint : Endpoint<SearchMovieNameRequest, SearchMovieNameResponse>
{
    private readonly IMovieRepository _movieRepository;

    public SearchMovieNameEndpoint(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public override void Configure()
    {
        Get("movies/name/{Name}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchMovieNameRequest req, CancellationToken ct)
    {
        var response = new SearchMovieNameResponse()
        {
            Movies = _movieRepository.GetAll().Where(m => m.Name.ToLower() == req.Name.ToLower()).ToList()
        };
        await SendAsync(response, cancellation: ct);
    }
}

public class DeletMovieEndpoint : Endpoint<DeleteMovieRequest>
{

    private readonly IMovieRepository _movieRepository;

    public DeletMovieEndpoint(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public override void Configure() 
    {
        Verbs(Http.DELETE);
        Routes("movies/id/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteMovieRequest req, CancellationToken ct)
    {
        if (_movieRepository.Remove(req.Id))
        {
            await SendNoContentAsync(ct);
            return;
        }
        await SendNotFoundAsync(ct);
    }
}
