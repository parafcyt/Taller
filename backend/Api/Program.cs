using Application.Destinations.Interfaces;
using Application.Destinations.Services;
using Domain.Repositories;
using Domain.Repositories.Base;
using Infraestructure.DataContext;
using Infraestructure.Repositories;
using Infraestructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Nuestro

// Connect to SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TallerContext>(options => options.UseSqlServer(connectionString));

// Repositorio genérico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Repositorios
builder.Services.AddTransient<IRatingScaleRepository, RatingScaleRepository>();
builder.Services.AddTransient<IDestinationRepository, DestinationRepository>();

// Servicios
builder.Services.AddScoped<IDestinationService, DestinationService>();

#endregion

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
