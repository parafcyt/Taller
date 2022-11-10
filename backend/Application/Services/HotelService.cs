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
        private readonly IRepository<HotelPhoto> iHotelPhotoRepository;
        private readonly IMapper iMapper;

        public HotelService(
            IRepository<Hotel> pHotelRepository, 
            IRepository<HotelPhoto> pHotelPhotoRepository,
            IMapper pMapper)
        {
            iHotelRepository = pHotelRepository;
            iHotelPhotoRepository = pHotelPhotoRepository;
            iMapper = pMapper;
        }
        public async Task<Hotel> AddHotel(CreateHotelInputDto pInput)
        {
            Hotel mHotel = iMapper.Map<Hotel>(pInput);

            return await iHotelRepository.AddAsync(mHotel);
        }

        public Task<HotelPhoto> AddHotelPhoto(CreateHotelPhotoInputDto pInput)
        {
            HotelPhoto mHotelPhoto = iMapper.Map<HotelPhoto>(pInput);

            return iHotelPhotoRepository.AddAsync(mHotelPhoto);
        }

        public async Task DeleteHotel(int pId)
        {
            Hotel? mHotel = await iHotelRepository.GetByIdAsync(pId);

            if (mHotel != null)
            {
                await iHotelRepository.DeleteAsync(mHotel);
            }
        }

        public async Task DeleteHotelPhoto(int pId)
        {
            HotelPhoto? mHotelPhoto = await iHotelPhotoRepository.GetByIdAsync(pId);

            if (mHotelPhoto != null)
            {
                await iHotelPhotoRepository.DeleteAsync(mHotelPhoto);
            }
        }

        public async Task<Hotel?> GetHotelById(int pId)
        {
            return await iHotelRepository.GetByIdAsync(pId);
        }

        public async Task<HotelPhoto?> GetHotelPhotoById(int pId)
        {
            return await iHotelPhotoRepository.GetByIdAsync(pId);
        }

        public IQueryable<HotelPhoto> GetHotelPhotos()
        {
            return iHotelPhotoRepository.AsQueryable();
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

        public async Task<HotelPhoto> UpdateHotelPhoto(UpdateHotelPhotoInputDto pInput)
        {
            HotelPhoto mHotelPhoto = iMapper.Map<HotelPhoto>(pInput);

            return await iHotelPhotoRepository.UpdateAsync(mHotelPhoto);
        }
    }
}
