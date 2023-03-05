using Api.Dtos.Hotels;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Api.GraphQL.Hotels
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class HotelMutation
    {
        private readonly IBaseService<Hotel> iHotelService;
        private readonly IBaseService<HotelPhoto> iHotelPhotoService;

        private readonly IMapper iMapper;

        public HotelMutation(
            [Service] IBaseService<Hotel> pHotelService,
            [Service] IBaseService<HotelPhoto> pHotelPhotoService,
            IMapper pMapper)
        {
            iHotelService = pHotelService;
            iHotelPhotoService = pHotelPhotoService;

            iMapper = pMapper;
        }

        public async Task<Hotel> AddHotel(CreateHotelDto pInput)
        {
            var mHotel = iMapper.Map<Hotel>(pInput);

            return await iHotelService.AddAsync(mHotel);
        }

        public async Task<Hotel> UpdateHotel(UpdateHotelDto pInput)
        {
            var mHotel = iMapper.Map<Hotel>(pInput);

            return await iHotelService.UpdateAsync(mHotel);
        }

        public async Task DeleteHotel(int pId)
        {
            await iHotelService.DeleteAsync(pId);
        }

        public async Task<HotelPhoto> AddHotelPhoto(CreateHotelPhotoDto pInput)
        {
            var mHotelPhoto = iMapper.Map<HotelPhoto>(pInput);

            return await iHotelPhotoService.AddAsync(mHotelPhoto);
        }

        public async Task<HotelPhoto> UpdateHotelPhoto(UpdateHotelPhotoDto pInput)
        {
            var mHotelPhoto = iMapper.Map<HotelPhoto>(pInput);

            return await iHotelPhotoService.UpdateAsync(mHotelPhoto);
        }

        public async Task DeleteHotelPhoto(int pId)
        {
            await iHotelPhotoService.DeleteAsync(pId);
        }
    }
}
