using Microsoft.EntityFrameworkCore;
using TalentX.WebScrapper.API.Data;
using TalentX.WebScrapper.API.Interface;
using TalentX.WebScrapper.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DataContext>(opt =>
//{
//    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IScrapDataRepo, DataRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DataContext>();
try
{
   context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message, "A problem occured during migration");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
