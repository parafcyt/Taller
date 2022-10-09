using Domain.Entities;
using Domain.Repositories.Base;
using Infraestructure.DataContext;

namespace Api.GraphQL.Destinations
{
    public class DestinationQuery
    {
        private readonly IRepository<Destination> iDestinationRepository;

        public DestinationQuery([Service] IRepository<Destination> pDestinationRepository)
        {
            iDestinationRepository = pDestinationRepository;
        }

        /// <summary>
        /// Permite hacer querys sobre la entidad destino
        /// </summary>
        /// <returns></returns>
        [UseProjection]
        public IQueryable<Destination> GetDestinations()
        {
            return iDestinationRepository.AsQueryable();
        }

        /// <summary>
        /// Obtiene un destino por Id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        [UseProjection]
        public async Task<Destination?> GetDestination(int pId)
        {
            return await iDestinationRepository.GetByIdAsync(pId);
        }
    }
}
