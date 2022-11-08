

using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Test.Data;
using Test.Data.Repositories.Implements;
using Test.Data.Repositories.Interfaces;
using TestWebAPI.Services.Implements;
using TestWebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = builder.Configuration;
builder.Services.AddDbContext<TestContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
