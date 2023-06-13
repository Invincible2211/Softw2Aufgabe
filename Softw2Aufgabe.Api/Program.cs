global using FastEndpoints;
using Softw2Aufgabe.Api.Services;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();

builder.Services.AddSingleton<IMovieRepository, MovieRepository>();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();
app.Run();