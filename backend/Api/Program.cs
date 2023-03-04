using Api.GraphQL;
using Application.Interfaces;
using Application.Services;
using Domain.Repositories.Base;
using Infraestructure.DataContext;
using Infraestructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

string cCORSOpenPolicy = "OpenCORSPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cCORSOpenPolicy,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Nuestro

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Connect to SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TallerContext>(options => options.UseSqlServer(connectionString));

// Repositorios
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Servicios
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

// GraphQL
GraphQLConfiguration.ConfigureGraphQL(builder.Services);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cCORSOpenPolicy);

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
