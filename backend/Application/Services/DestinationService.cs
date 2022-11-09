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
        private readonly IMapper iMapper;

        public DestinationService(IRepository<Destination> pDestinationRepository, IMapper pMapper)
        {
            iDestinationRepository = pDestinationRepository;
            iMapper = pMapper;
        }

        #region Métodos públicos

        public async Task<Destination> AddDestination(CreateDestinationInputDto pInputDestinationDto)
        {
            Destination mDestination = iMapper.Map<CreateDestinationInputDto, Destination>(pInputDestinationDto);

            return await iDestinationRepository.AddAsync(mDestination);
        }

        public async Task DeleteDestination(int pId)
        {
            Destination? mDestination = await iDestinationRepository.GetByIdAsync(pId);

            if (mDestination != null)
            {
                await iDestinationRepository.DeleteAsync(mDestination);
            }
        }

        public async Task<Destination?> GetDestinationById(int pId)
        {
            return await iDestinationRepository.GetByIdAsync(pId);
        }

        public IQueryable<Destination> GetDestinations()
        {
            return iDestinationRepository.AsQueryable();
        }

        public async Task<Destination> UpdateDestination(UpdateDestinationInputDto pDestinationDto)
        {
            Destination mDestination = iMapper.Map<UpdateDestinationInputDto, Destination>(pDestinationDto);

            return await iDestinationRepository.UpdateAsync(mDestination);
        }

        #endregion
    }
}
