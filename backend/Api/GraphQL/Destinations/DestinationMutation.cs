using Api.Dtos.Destinations;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using HotChocolate.Execution;

namespace Api.GraphQL.Destinations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class DestinationMutation
    {
        private readonly IBaseService<Destination> iDestinationService;
        private readonly IBaseService<DestinationPhoto> iDestinationPhotoService;

        private readonly IMapper iMapper;

        public DestinationMutation(
            [Service] IBaseService<Destination> pDestinationService,
            [Service] IBaseService<DestinationPhoto> pDestinationPhotoService,
            IMapper pMapper)
        {
            iDestinationService = pDestinationService;
            iDestinationPhotoService = pDestinationPhotoService;

            iMapper = pMapper;
        }

        public async Task<Destination> AddDestination(CreateDestinationInputDto pInput)
        {
            //HAGO VALIDACIONES ACA
            if (pInput.Name == null)
            {
                throw new QueryException(ErrorBuilder.New().SetMessage("").SetCode("").Build());
            }

            var mDestination = iMapper.Map<Destination>(pInput);

            return await iDestinationService.AddAsync(mDestination);
        }

        public async Task<Destination> UpdateDestination(UpdateDestinationInputDto pInput)
        {
            var mDestination = iMapper.Map<Destination>(pInput);

            return await iDestinationService.UpdateAsync(mDestination);
        }

        public async Task DeleteDestination(int pId)
        {
            await iDestinationService.DeleteAsync(pId);
        }

        public async Task<DestinationPhoto> AddDestinationPhoto(CreateDestinationPhotoInputDto pInput)
        {
            var mDestinationPhoto = iMapper.Map<DestinationPhoto>(pInput);

            return await iDestinationPhotoService.AddAsync(mDestinationPhoto);
        }

        public async Task<DestinationPhoto> UpdateDestinationPhoto(UpdateDestinationPhotoInputDto pInput)
        {
            var mDestinationPhoto = iMapper.Map<DestinationPhoto>(pInput);

            return await iDestinationPhotoService.UpdateAsync(mDestinationPhoto);
        }

        public async Task DeleteDestinationPhoto(int pId)
        {
            await iDestinationPhotoService.DeleteAsync(pId);
        }
    }
}
