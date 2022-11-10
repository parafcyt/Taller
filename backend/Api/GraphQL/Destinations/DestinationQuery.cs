using Application.Interfaces;
using Domain.Entities;

namespace Api.GraphQL.Destinations
{
    public class DestinationQuery
    {
        private readonly IBaseService<Destination> iDestinationService;
        private readonly IBaseService<DestinationPhoto> iDestinationPhotoService;

        public DestinationQuery(
            [Service] IBaseService<Destination> pDestinationService,
            [Service] IBaseService<DestinationPhoto> pDestinationPhotoService)
        {
            iDestinationService = pDestinationService;
            iDestinationPhotoService = pDestinationPhotoService;
        }

        /// <summary>
        /// Permite hacer querys sobre la entidad destino
        /// </summary>
        /// <returns></returns>
        [UseProjection]
        public IQueryable<Destination> GetDestinations()
        {
            return iDestinationService.GetAllAsync();
        }

        /// <summary>
        /// Obtiene un destino por Id
        /// </summary>
        /// <param name="pId">identificador</param>
        /// <returns></returns>
        [UseProjection]
        public async Task<Destination?> GetDestination(int pId)
        {
            return await iDestinationService.GetByIdAsync(pId);
        }

        [UseProjection]
        public IQueryable<DestinationPhoto> GetDestinationPhotos()
        {
            return iDestinationPhotoService.GetAllAsync();
        }

        [UseProjection]
        public async Task<DestinationPhoto?> GetDestinationPhoto(int pId)
        {
            return await iDestinationPhotoService.GetByIdAsync(pId);
        }
    }
}
