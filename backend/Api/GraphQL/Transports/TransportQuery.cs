using Application.Interfaces;
using Domain.Entities;
using UseFilteringAttribute = HotChocolate.Data.UseFilteringAttribute;
using UseSortingAttribute = HotChocolate.Data.UseSortingAttribute;

namespace Api.GraphQL.Transports
{
    [ExtendObjectType("Query")]
    public class TransportQuery
    {
        private readonly IBaseService<Transport> iTransportService;

        public TransportQuery([Service] IBaseService<Transport> pTransportService)
        {
            iTransportService = pTransportService;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Transport> GetTransports()
        {
            return iTransportService.GetQueryable();
        }
    }
}
