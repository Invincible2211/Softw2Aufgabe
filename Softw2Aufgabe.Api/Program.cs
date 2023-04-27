global using FastEndpoints;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints(); // Das

var app = builder.Build();
app.UseAuthorization(); // Das
app.UseFastEndpoints(); // Das
app.Run();