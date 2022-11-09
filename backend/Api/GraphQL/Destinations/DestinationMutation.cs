using Application.Dtos.Destinations;
using Application.Interfaces;
using Domain.Entities;
using HotChocolate.Execution;

namespace Api.GraphQL.Destinations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class DestinationMutation
    {
        private readonly IDestinationService iDestinationService;

        public DestinationMutation([Service] IDestinationService pDestinationService)
        {
            iDestinationService = pDestinationService;
        }

        /// <summary>
        /// Agrega un destino
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public async Task<Destination> AddDestination(CreateDestinationInputDto pInput)
        {
            //HAGO VALIDACIONES ACA
            if (pInput.Name == null)
            {
                throw new QueryException(ErrorBuilder.New().SetMessage("").SetCode("").Build());
            }

            return await iDestinationService.AddDestination(pInput);
        }

        /// <summary>
        /// Actualiza un destino
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public async Task<Destination> UpdateDestination(UpdateDestinationInputDto pInput)
        {
            //TODO: Hacer validaciones
            return await iDestinationService.UpdateDestination(pInput);
        }

        /// <summary>
        /// Elimina un destino
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task DeleteDestination(int pId)
        {
            await iDestinationService.DeleteDestination(pId);
        }
    }
}
