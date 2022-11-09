
namespace Api.GraphQL.Hotels
{
    public class HotelQueryType : ObjectTypeExtension<HotelQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<HotelQuery> descriptor) =>
            descriptor
            .Name("Query")
            .Field(f => f.GetHotels());
    }
}
