var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//context - HttpContext - объект который содержит данные запроса и будущего ответа
app.Run(async (context) =>
{
    await context.Response.WriteAsync("test string");
});

app.Run(async (context) =>
{
    string agentName = context.Request.Headers["User-Agent"];
    await context.Response.WriteAsync(agentName);
});


app.Run();