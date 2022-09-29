using Application.Interfaces;
using Application.Dtos.Destinations;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Application.Dtos;

namespace Application.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository iDestinationRepository;

        public DestinationService(IDestinationRepository pDestinationRepository)
        {
            iDestinationRepository = pDestinationRepository;
        }

        #region Métodos públicos

        public async Task<GenericOutputDto> AddDestination(InputDestinationDto pInputDestinationDto)
        {
            try
            {
                Destination mDestination = new Destination
                {
                    Name = pInputDestinationDto.Name,
                    Description = pInputDestinationDto.Description
                };

                await iDestinationRepository.AddAsync(mDestination);

                return new GenericOutputDto
                {
                    Code = 200,
                    Message = "Destino insertado exitosamente"
                };
            }
            catch (Exception e)
            {
                return new GenericOutputDto
                {
                    Code = 500,
                    Message = "Error al insertar Destino",
                    Details = e.Message
                };
            }
        }

        public async Task<GenericOutputDto> DeleteDestination(int pId)
        {
            try
            {
                var mDestination = await iDestinationRepository.GetByIdAsync(pId);

                if (mDestination != null)
                {
                    await iDestinationRepository.DeleteAsync(mDestination);

                    return new GenericOutputDto
                    {
                        Code = 200,
                        Message = "Destino eliminado exitosamente"
                    };
                }
                else
                {
                    return new GenericOutputDto
                    {
                        Code = 404,
                        Message = "Destino no encontrado"
                    };
                }
            }
            catch (Exception e)
            {
                return new GenericOutputDto
                {
                    Code = 500,
                    Message = "Error al eliminar Destino",
                    Details = e.Message
                };
            }
        }

        public async Task<DestinationDto?> GetDestinationById(int pId)
        {
            var mDestination = await iDestinationRepository.GetByIdAsync(pId);

            if (mDestination != null)
            {
                return new DestinationDto
                {
                    DestinationId = mDestination.DestinationId,
                    Name = mDestination.Name,
                    Description = mDestination.Description
                };
            }

            return null;
        }

        public async Task<IEnumerable<DestinationDto>> GetDestinations()
        {
            var mList = await iDestinationRepository.GetAllAsync();

            var mListResult = new List<DestinationDto>();

            foreach (var bDestination in mList)
            {
                mListResult.Add(
                    new DestinationDto
                    {
                        DestinationId = bDestination.DestinationId,
                        Name = bDestination.Name,
                        Description = bDestination.Description
                    });
            }

            return mListResult;
        }

        public async Task<GenericOutputDto> UpdateDestination(DestinationDto pDestinationDto)
        {
            try
            {
                Destination mDestination = new Destination
                {
                    DestinationId = pDestinationDto.DestinationId,
                    Name = pDestinationDto.Name,
                    Description = pDestinationDto.Description
                };

                await iDestinationRepository.UpdateAsync(mDestination);

                return new GenericOutputDto
                {
                    Code = 200,
                    Message = "Destino actualizado exitosamente"
                };
            }
            catch (Exception e)
            {
                return new GenericOutputDto
                {
                    Code = 500,
                    Message = "Error al actualizar Destino",
                    Details = e.Message
                };
            } 
        }

        #endregion
    }
}
