var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Services.AddMvc();

app.Map("/path1", branch =>
{
    branch.Run(async context =>
    {
        string path = context.Request.Path;
        string pathBase = context.Request.PathBase;

        await context.Response.WriteAsync($"path branch. Path: {path}, PathBase: {pathBase}");
    });
});

app.Map("/path2/path3", branch =>
{
    branch.Run(async context =>
    {
        string path = context.Request.Path;
        string pathBase = context.Request.PathBase;

        await context.Response.WriteAsync($"path branch. Path: {path}, PathBase: {pathBase}");
    });
});

app.Run(async context =>
{
    string path = context.Request.Path;
    string pathBase = context.Request.PathBase;

    await context.Response.WriteAsync($"path branch. Path: {path}, PathBase: {pathBase}");
});

app.Map("/health-check", branch =>
{
    branch.UseExceptionHandler("/Error");
    branch.Run(async context =>
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("OK");
    });
});

app.Run(async (context) =>
{
    string agentName = context.Request.Headers["User-Agent"];
    await context.Response.WriteAsync(agentName);
});

app.Run();
