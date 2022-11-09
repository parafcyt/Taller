using Application.Dtos.Hotels;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Base;

namespace Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> iHotelRepository;
        private readonly IMapper iMapper;

        public HotelService(IRepository<Hotel> pHotelRepository, IMapper pMapper)
        {
            iHotelRepository = pHotelRepository;
            iMapper = pMapper;
        }
        public Task<Hotel> AddHotel(CreateHotelInputDto pInput)
        {
            Hotel mHotel = iMapper.Map<Hotel>(pInput);

            return iHotelRepository.AddAsync(mHotel);
        }

        public async Task DeleteHotel(int pId)
        {
            Hotel? mHotel = await iHotelRepository.GetByIdAsync(pId);

            if (mHotel != null)
            {
                await iHotelRepository.DeleteAsync(mHotel);
            }
        }

        public async Task<Hotel?> GetHotelById(int pId)
        {
            return await iHotelRepository.GetByIdAsync(pId);
        }

        public IQueryable<Hotel> GetHotels()
        {
            return iHotelRepository.AsQueryable();
        }

        public Task<Hotel> UpdateHotel(UpdateHotelInputDto pInput)
        {
            Hotel mHotel = iMapper.Map<Hotel>(pInput);

            return iHotelRepository.UpdateAsync(mHotel);
        }
    }
}
