using Api.GraphQL.Destinations;
using Application.Interfaces;
using Application.Services;
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

// Repositorio gen�rico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Repositorios
builder.Services.AddTransient<IRatingScaleRepository, RatingScaleRepository>();
builder.Services.AddTransient<IDestinationRepository, DestinationRepository>();

// Servicios
builder.Services.AddScoped<IDestinationService, DestinationService>();

// GraphQL
builder.Services.AddGraphQLServer()
    .RegisterDbContext<TallerContext>()

#region Querys

    .AddQueryType(t => t.Name("Query"))
        .AddType<DestinationQueryType>()

#endregion

#region Mutations

    .AddMutationType()
        .AddTypeExtension<DestinationMutation>()

#endregion

    .AddProjections();

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

app.MapGraphQL();

app.Run();
