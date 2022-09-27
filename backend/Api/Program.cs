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

// Connect to SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TallerContext>(options => options.UseSqlServer(connectionString));

//repo generico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//repos
builder.Services.AddTransient<IRatingScaleRepository, RatingScaleRepository>();


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
