using _05_pipline;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseMiddleware<ContentMiddleware>();
app.cme();

app.MapGet("/", () => "Hello World!");

app.Run();
