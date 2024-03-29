﻿using Application.Dtos;
using Application.Dtos.Destinations;

namespace Application.Interfaces
{
    public interface IDestinationService
    {
        /// <summary>
        /// Obtiene un destino mediante identificador
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        Task<DestinationDto?> GetDestinationById(int pId);

        /// <summary>
        /// Obtiene todos los destinos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DestinationDto>> GetDestinations();

        /// <summary>
        /// Agrega un destino
        /// </summary>
        /// <param name="pInputDestinationDto"></param>
        /// <returns></returns>
        Task<GenericOutputDto> AddDestination(InputDestinationDto pInputDestinationDto);

        /// <summary>
        /// Actualiza un destino
        /// </summary>
        /// <param name="pDestinationDto"></param>
        /// <returns></returns>
        Task<GenericOutputDto> UpdateDestination(DestinationDto pDestinationDto);

        /// <summary>
        /// Elimina un destino
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        Task<GenericOutputDto> DeleteDestination(int pId);
    }
}
