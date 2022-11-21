using Transleader.LibraryServer.DataAccessL;
using Microsoft.EntityFrameworkCore;
using LibgenApi.IS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

BookController bookController = new BookController();

using HttpResponseMessage response = 
    await bookController.GetDateArea(DateMode.last, new DateTime(2018,01,01));
{
    response.EnsureSuccessStatusCode();
    Console.WriteLine(await response.Content.ReadAsStringAsync());
}

builder.Services.AddDbContext<BookDbContext>(
    options => options.UseSqlServer(
        ConfigurationExtensions.GetConnectionString(builder.Configuration, "SqlServerBookBase")));
builder.Services.AddControllers();
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
