global using FastEndpoints;
using Softw2Aufgabe.Api;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints(); // Das
Data.AddMovie(new Movie("Test1"));
Data.AddMovie(new Movie("Test2"));
Data.AddMovie(new Movie("Test3"));
var app = builder.Build();
app.UseAuthorization(); // Das
app.UseFastEndpoints(); // Das
app.Run();