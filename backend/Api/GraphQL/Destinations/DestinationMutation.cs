using Application.Dtos.Destinations;
using Domain.Entities;
using Infraestructure.DataContext;

namespace Api.GraphQL.Destinations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class DestinationMutation
    {
        /// <summary>
        /// Agrega un destino
        /// </summary>
        /// <param name="tallerContext"></param>
        /// <param name="inputDestinationDto"></param>
        /// <returns></returns>
        public async Task<Destination> AddDestination(
            TallerContext tallerContext,
            InputDestinationDto inputDestinationDto)
        {
            var mDestination = new Destination
            {
                Name = inputDestinationDto.Name,
                Description = inputDestinationDto.Description
            };

            tallerContext.Destinations.Add(mDestination);
            await tallerContext.SaveChangesAsync();

            return mDestination;
        }

        /// <summary>
        /// Actualiza un destino
        /// </summary>
        /// <param name="tallerContext"></param>
        /// <param name="pDestination"></param>
        /// <returns></returns>
        public async Task<Destination> UpdateDestination(
            TallerContext tallerContext,
            Destination pDestination)
        {
            tallerContext.Destinations.Update(pDestination);
            await tallerContext.SaveChangesAsync();

            return pDestination;
        }

        /// <summary>
        /// Elimina un destino
        /// </summary>
        /// <param name="tallerContext"></param>
        /// <param name="pId"></param>
        /// <returns>Booleano que indica si se eliminó el destino</returns>
        public async Task<bool> DeleteDestination(
            TallerContext tallerContext,
            int pId)
        {
            var mDestination = tallerContext.Destinations.FirstOrDefault(x => x.DestinationId == pId);

            if (mDestination != null)
            {
                tallerContext.Destinations.Remove(mDestination);
                await tallerContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
