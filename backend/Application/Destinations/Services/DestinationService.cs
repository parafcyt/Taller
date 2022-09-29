using Application.Destinations.Dtos;
using Application.Destinations.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository iDestinationRepository;

        public DestinationService(IDestinationRepository pDestinationRepository)
        {
            iDestinationRepository = pDestinationRepository;
        }

        #region Métodos públicos

        public async Task AddDestination(InputDestinationDto pInputDestinationDto)
        {
            Destination mDestination = new Destination
            {
                Name = pInputDestinationDto.Name,
                Description = pInputDestinationDto.Description
            };

            await iDestinationRepository.AddAsync(mDestination);
        }

        public async Task DeleteDestination(int pId)
        {
            var mDestination = await iDestinationRepository.GetByIdAsync(pId);

            if (mDestination != null)
            {
                await iDestinationRepository.DeleteAsync(mDestination);
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

        public async Task UpdateDestination(DestinationDto pDestinationDto)
        {
            Destination mDestination = new Destination
            {
                DestinationId = pDestinationDto.DestinationId,
                Name = pDestinationDto.Name,
                Description = pDestinationDto.Description
            };

            await iDestinationRepository.UpdateAsync(mDestination);
        }

        #endregion
    }
}
