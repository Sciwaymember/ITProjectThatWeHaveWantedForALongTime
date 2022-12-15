using Transleader.LibraryServer.DataAccessL;
using Microsoft.EntityFrameworkCore;
using Transleader.LibraryServer.BusinessL.Repositories;
using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.BusinessL;
using Transleader.LibraryServer.BusinessL.Settings.DbUpdater;

var builder = WebApplication.CreateBuilder(args);

// Adding dependencies to services for later use in the solution
builder.Services.AddDbContext<BookDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerBookBase")));
builder.Services.AddScoped<IRepository<BookBL>, SQLServerBookRepository>();
builder.Configuration.AddJsonFile("dbUpdaterConfig.json", optional: true, reloadOnChange: true);

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

Task.Run(async () =>
{
    using (var dbUpdater = new DatabaseUpdater(
    new DbUpdaterConfig(builder.Configuration),
    builder.Configuration.GetConnectionString("SqlServerBookBase")))
    {
        await Task.WhenAny(
            dbUpdater.canselTask,
            dbUpdater.UpdateAsync());
    }
});

app.Run();
