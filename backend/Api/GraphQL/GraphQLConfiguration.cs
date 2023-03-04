using Api.GraphQL.Destinations;
using Api.GraphQL.Hotels;
using Api.GraphQL.Transports;
using Infraestructure.DataContext;

namespace Api.GraphQL
{
    public static class GraphQLConfiguration
    {
        public static IServiceCollection ConfigureGraphQL(this IServiceCollection pServiceCollection)
        {
            // Agrego las querys y mutations al scope de la aplicación para poder ser injectadas
            pServiceCollection.AddScoped<DestinationQuery>();
            pServiceCollection.AddScoped<DestinationMutation>();
            pServiceCollection.AddScoped<HotelQuery>();
            pServiceCollection.AddScoped<HotelMutation>();
            pServiceCollection.AddScoped<TransportQuery>();
            pServiceCollection.AddScoped<TransportMutation>();

            // Vincula GraphQL con el contexto de la BBDD
            pServiceCollection
                .AddGraphQLServer().RegisterDbContext<TallerContext>()

                // Configuro las querys
                .AddQueryType(t => t.Name("Query"))
                    .AddType<DestinationQuery>()
                    .AddType<HotelQuery>()
                    .AddType<TransportQuery>()

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
