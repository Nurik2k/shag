using Microsoft.Net.Http.Headers;
using WebApiLesson.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddCors();
app.UseCors(builder =>
{
    builder

    //условия
    //.WithOrigins("http://localhost:5245")
    //.WithOrigins(new string[] { "http://localhost:5245", "..." })
    //.WithHeaders(HeaderNames.ContentType, "x-customer-header")

    //.WithOrigins("http://*.otbasybank.kz")
    //.AllowAnyHeader("h1" , "h2")
    //.WithMethods('GET')

    //для всех
    .AllowAnyHeader().
    AllowAnyMethod()
    .AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
