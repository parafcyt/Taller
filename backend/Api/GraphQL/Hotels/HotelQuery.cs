using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Api.GraphQL.Hotels
{
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
        public IQueryable<Hotel> GetHotels()
        {
            return iHotelService.GetAllAsync();
        }

        [UseProjection]
        public async Task<Hotel?> GetHotel(int pId)
        {
            return await iHotelService.GetByIdAsync(pId);
        }

        [UseProjection]
        public IQueryable<HotelPhoto> GetHotelPhotos()
        {
            return iHotelPhotoService.GetAllAsync();
        }

        [UseProjection]
        public async Task<HotelPhoto?> GetHotelPhoto(int pId)
        {
            return await iHotelPhotoService.GetByIdAsync(pId);
        }
    }
}
