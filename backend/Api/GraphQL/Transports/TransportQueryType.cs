
namespace Api.GraphQL.Transports
{
    public class TransportQueryType : ObjectTypeExtension<TransportQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<TransportQuery> descriptor) =>
            descriptor
            .Name("Query")
            .Field(f => f.GetTransports());
    }
}
