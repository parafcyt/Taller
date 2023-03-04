using Application.Interfaces;
using Domain.Entities;
using UseFilteringAttribute = HotChocolate.Data.UseFilteringAttribute;
using UseSortingAttribute = HotChocolate.Data.UseSortingAttribute;

namespace Api.GraphQL.Hotels
{
    [ExtendObjectType("Query")]
    public class HotelQuery
    {
        private readonly IBaseService<Hotel> iHotelService;
        private readonly IBaseService<HotelPhoto> iHotelPhotoService;

        public HotelQuery(
            [Service] IBaseService<Hotel> pHotelService,
            [Service] IBaseService<HotelPhoto> pHotelPhotoService)
        {
            iHotelService = pHotelService;
            iHotelPhotoService = pHotelPhotoService;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Hotel> GetHotels()
        {
            return iHotelService.GetQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<HotelPhoto> GetHotelPhotos()
        {
            return iHotelPhotoService.GetQueryable();
        }
    }
}
