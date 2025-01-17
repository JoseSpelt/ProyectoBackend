using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PrimerProyectoBackend.Automappers;
using PrimerProyectoBackend.DTO;
using PrimerProyectoBackend.Models;
using PrimerProyectoBackend.Repository;
using PrimerProyectoBackend.Services;
using PrimerProyectoBackend.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPeopleService, People2Service>();

builder.Services.AddControllers();

builder.Services.AddScoped<IPostsService, PostsService>();
builder.Services.AddKeyedScoped<ICommomService< BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>("beerService");
// HttpClient servicio jsonplaceholder
builder.Services.AddHttpClient<IPostsService, PostsService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});
// Repository
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();

// Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("StoreConnection"));
});

// Validators
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();
// Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));
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
