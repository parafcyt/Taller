using Application.Dtos.Hotels;
using Application.Interfaces;
using Domain.Entities;

namespace Api.GraphQL.Hotels
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class HotelMutation
    {
        private readonly IHotelService iHotelService;

        public HotelMutation([Service] IHotelService pHotelService)
        {
            iHotelService = pHotelService;
        }

        public async Task<Hotel> AddHotel(CreateHotelInputDto pInput)
        {
            return await iHotelService.AddHotel(pInput);
        }

        public async Task<Hotel> UpdateHotel(UpdateHotelInputDto pInput)
        {
            return await iHotelService.UpdateHotel(pInput);
        }

        public async Task DeleteHotel(int pId)
        {
            await iHotelService.DeleteHotel(pId);
        }

        public async Task<HotelPhoto> AddHotelPhoto(CreateHotelPhotoInputDto pInput)
        {
            return await iHotelService.AddHotelPhoto(pInput);
        }

        public async Task<HotelPhoto> UpdateHotelPhoto(UpdateHotelPhotoInputDto pInput)
        {
            return await iHotelService.UpdateHotelPhoto(pInput);
        }

        public async Task DeleteHotelPhoto(int pId)
        {
            await iHotelService.DeleteHotel(pId);
        }
    }
}
