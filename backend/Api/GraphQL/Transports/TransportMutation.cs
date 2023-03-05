using Api.Dtos.Transports;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Api.GraphQL.Transports
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class TransportMutation
    {
        private readonly IBaseService<Transport> iTransportService;

        private readonly IMapper iMapper;

        public TransportMutation(
            [Service] IBaseService<Transport> pTransportService,
            IMapper pMapper)
        {
            iTransportService = pTransportService;

            iMapper = pMapper;
        }

        public async Task<Transport> AddTransport(CreateTransportDto pInput)
        {
            var mTransport = iMapper.Map<Transport>(pInput);

            return await iTransportService.AddAsync(mTransport);
        }

        public async Task<Transport> UpdateTransport(UpdateTransportDto pInput)
        {
            var mTransport = iMapper.Map<Transport>(pInput);

            return await iTransportService.UpdateAsync(mTransport);
        }

        public async Task DeleteTransport(int pId)
        {
            await iTransportService.DeleteAsync(pId);
        }
    }
}
