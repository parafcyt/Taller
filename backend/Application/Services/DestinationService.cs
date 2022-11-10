using Application.Interfaces;
using Application.Dtos.Destinations;
using Domain.Entities;
using Domain.Repositories.Base;
using AutoMapper;

namespace Application.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository<Destination> iDestinationRepository;
        private readonly IRepository<DestinationPhoto> iDestinationPhotoRepository;
        private readonly IMapper iMapper;

        public DestinationService(
            IRepository<Destination> pDestinationRepository, 
            IRepository<DestinationPhoto> pDestinationPhotoRepository,
            IMapper pMapper)
        {
            iDestinationRepository = pDestinationRepository;
            iDestinationPhotoRepository = pDestinationPhotoRepository;
            iMapper = pMapper;
        }

        #region Métodos públicos

        public async Task<Destination> AddDestination(CreateDestinationInputDto pInput)
        {
            Destination mDestination = iMapper.Map<Destination>(pInput);

            return await iDestinationRepository.AddAsync(mDestination);
        }

        public async Task<DestinationPhoto> AddDestinationPhoto(CreateDestinationPhotoInputDto pInput)
        {
            DestinationPhoto mDestinationPhoto = iMapper.Map<DestinationPhoto>(pInput);

            return await iDestinationPhotoRepository.AddAsync(mDestinationPhoto);
        }

        public async Task DeleteDestination(int pId)
        {
            Destination? mDestination = await iDestinationRepository.GetByIdAsync(pId);

            if (mDestination != null)
            {
                await iDestinationRepository.DeleteAsync(mDestination);
            }
        }

        public async Task DeleteDestinationPhoto(int pId)
        {
            DestinationPhoto? mDestinationPhoto = await iDestinationPhotoRepository.GetByIdAsync(pId);

            if (mDestinationPhoto != null)
            {
                await iDestinationPhotoRepository.DeleteAsync(mDestinationPhoto);
            }
        }

        public async Task<Destination?> GetDestinationById(int pId)
        {
            return await iDestinationRepository.GetByIdAsync(pId);
        }

        public async Task<DestinationPhoto?> GetDestinationPhotoById(int pId)
        {
            return await iDestinationPhotoRepository.GetByIdAsync(pId);
        }

        public IQueryable<DestinationPhoto> GetDestinationPhotos()
        {
            return iDestinationPhotoRepository.AsQueryable();
        }

        public IQueryable<Destination> GetDestinations()
        {
            return iDestinationRepository.AsQueryable();
        }

        public async Task<Destination> UpdateDestination(UpdateDestinationInputDto pInput)
        {
            Destination mDestination = iMapper.Map<Destination>(pInput);

            return await iDestinationRepository.UpdateAsync(mDestination);
        }

        public async Task<DestinationPhoto> UpdateDestinationPhoto(UpdateDestinationPhotoInputDto pInput)
        {
            DestinationPhoto mDestinationPhoto = iMapper.Map<DestinationPhoto>(pInput);

            return await iDestinationPhotoRepository.UpdateAsync(mDestinationPhoto);
        }

        #endregion
    }
}
