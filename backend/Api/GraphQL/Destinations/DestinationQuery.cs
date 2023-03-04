using Application.Interfaces;
using Domain.Entities;
using UseFilteringAttribute = HotChocolate.Data.UseFilteringAttribute;
using UseSortingAttribute = HotChocolate.Data.UseSortingAttribute;

namespace Api.GraphQL.Destinations
{
    [ExtendObjectType("Query")]
    public class DestinationQuery
    {
        private readonly IBaseService<Destination> iDestinationService;
        private readonly IBaseService<DestinationPhoto> iDestinationPhotoService;

        public DestinationQuery(
            [Service] IBaseService<Destination> pDestinationService,
            [Service] IBaseService<DestinationPhoto> pDestinationPhotoService)
        {
            iDestinationService = pDestinationService;
            iDestinationPhotoService = pDestinationPhotoService;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Destination> GetDestinations()
        {
            return iDestinationService.GetQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<DestinationPhoto> GetDestinationPhotos()
        {
            return iDestinationPhotoService.GetQueryable();
        }
    }
}
