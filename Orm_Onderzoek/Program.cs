using DataAccess;
using DataAccess.Repositories;
using Interface.Interface;
using Logic.Container;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
builder.Services.AddScoped<IBookContainer, BookContainer>();
builder.Services.AddScoped<IAuthorContainer, AuthorContainer>();
builder.Services.AddScoped<IGenreContainer, GenreContainer>();
builder.Services.AddScoped<IBookGenreContainer, BookGenreContainer>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin();
        corsPolicyBuilder.AllowAnyMethod();
        corsPolicyBuilder.AllowAnyHeader();
    });
});

var app = builder.Build();


app.UseWebSockets();

app.UseCors("AllowAll");

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