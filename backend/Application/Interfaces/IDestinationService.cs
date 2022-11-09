using Application.Dtos;
using Application.Dtos.Destinations;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDestinationService
    {
        /// <summary>
        /// Obtiene un destino mediante identificador
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        Task<Destination?> GetDestinationById(int pId);

        /// <summary>
        /// Obtiene todos los destinos
        /// </summary>
        /// <returns></returns>
        IQueryable<Destination> GetDestinations();

        /// <summary>
        /// Agrega un destino
        /// </summary>
        /// <param name="pInputDestinationDto"></param>
        /// <returns></returns>
        Task<Destination> AddDestination(CreateDestinationInputDto pInputDestinationDto);

        /// <summary>
        /// Actualiza un destino
        /// </summary>
        /// <param name="pDestinationDto"></param>
        /// <returns></returns>
        Task<Destination> UpdateDestination(UpdateDestinationInputDto pDestinationDto);

        /// <summary>
        /// Elimina un destino
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        Task DeleteDestination(int pId);
    }
}
