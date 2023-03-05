using Api.GraphQL.Destinations;
using Api.GraphQL.Hotels;
using Api.GraphQL.RatingScales;
using Api.GraphQL.Transports;
using Infraestructure.DataContext;

namespace Api.GraphQL
{
    public static class GraphQLConfiguration
    {
        public static IServiceCollection ConfigureGraphQL(this IServiceCollection pServiceCollection)
        {
            // Agrego los servicios de querys y mutations como Scoped: Cada servicio scoped se creará una vez por request
            pServiceCollection.AddScoped<DestinationQuery>();
            pServiceCollection.AddScoped<DestinationMutation>();
            pServiceCollection.AddScoped<HotelQuery>();
            pServiceCollection.AddScoped<HotelMutation>();
            pServiceCollection.AddScoped<TransportQuery>();
            pServiceCollection.AddScoped<TransportMutation>();
            pServiceCollection.AddScoped<RatingScaleQuery>();

            // Vincula GraphQL con el contexto de la BBDD
            pServiceCollection
                .AddGraphQLServer().RegisterDbContext<TallerContext>()

                // Configuro las querys
                .AddQueryType(t => t.Name("Query"))
                    .AddType<DestinationQuery>()
                    .AddType<HotelQuery>()
                    .AddType<TransportQuery>()
                    .AddType<RatingScaleQuery>()

                // Configuro las mutations
                .AddMutationType()
                    .AddTypeExtension<DestinationMutation>()
                    .AddTypeExtension<HotelMutation>()
                    .AddTypeExtension<TransportMutation>()

                // Configuro otras caracteristicas de GraphQL
                .AddProjections() // Proyección permite navegar entre las relaciones de las entidades
                .AddFiltering()   // Agrega la posibilidad de filtrar las entidades
                .AddSorting()     // Agrega ordenamiento
                ;

            return pServiceCollection;
        }
    }
}
