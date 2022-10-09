namespace Api.GraphQL.Destinations
{
    public class DestinationQueryType : ObjectTypeExtension<DestinationQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<DestinationQuery> descriptor) =>
            descriptor.Name("Query").Field(f => f.GetDestinations());
    }
}
