using ASP.NET_Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// custom middleware
app.UseLogginMiddleWare();

app.Run();
