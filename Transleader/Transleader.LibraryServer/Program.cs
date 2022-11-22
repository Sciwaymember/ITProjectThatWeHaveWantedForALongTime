using Transleader.LibraryServer.DataAccessL;
using Microsoft.EntityFrameworkCore;
using LibgenApi.IS;
using Transleader.LibraryServer.BusinessL.Repositories;
using Transleader.LibraryServer.BusinessL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adding dependencies to services for later use in the solution
builder.Services.AddDbContext<BookDbContext>(
    options => options.UseSqlServer(
        ConfigurationExtensions.GetConnectionString(builder.Configuration, "SqlServerBookBase")));
builder.Services.AddScoped<IRepository<BookModel>, SQLServerBookRepository>();

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
