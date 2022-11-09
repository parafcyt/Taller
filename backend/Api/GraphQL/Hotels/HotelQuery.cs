using Application.Interfaces;
using Domain.Entities;

namespace Api.GraphQL.Hotels
{
    public class HotelQuery
    {
        private readonly IHotelService iHotelService;

        public HotelQuery([Service] IHotelService pHotelService)
        {
            iHotelService = pHotelService;
        }

        [UseProjection]
        public IQueryable<Hotel> GetHotels()
        {
            return iHotelService.GetHotels();
        }

        [UseProjection]
        public async Task<Hotel?> GetHotel(int pId)
        {
            return await iHotelService.GetHotelById(pId);
        }
    }
}
