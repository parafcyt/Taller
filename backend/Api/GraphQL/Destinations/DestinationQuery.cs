using Application.Interfaces;
using Domain.Entities;

namespace Api.GraphQL.Destinations
{
    public class DestinationQuery
    {
        private readonly IDestinationService iDestinationService;

        public DestinationQuery([Service] IDestinationService pDestinationService)
        {
            iDestinationService = pDestinationService;
        }

        /// <summary>
        /// Permite hacer querys sobre la entidad destino
        /// </summary>
        /// <returns></returns>
        [UseProjection]
        public IQueryable<Destination> GetDestinations()
        {
            //return iDestinationRepository.AsQueryable();
            return iDestinationService.GetDestinations();
        }

        /// <summary>
        /// Obtiene un destino por Id
        /// </summary>
        /// <param name="pId">identificador</param>
        /// <returns></returns>
        [UseProjection]
        public async Task<Destination?> GetDestination(int pId)
        {
            return await iDestinationService.GetDestinationById(pId);
        }
    }
}
