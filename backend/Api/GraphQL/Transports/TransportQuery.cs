using Application.Interfaces;
using Domain.Entities;

namespace Api.GraphQL.Transports
{
    public class TransportQuery
    {
        private readonly IBaseService<Transport> iTransportService;

        public TransportQuery([Service] IBaseService<Transport> pTransportService)
        {
            iTransportService = pTransportService;
        }

        [UseProjection]
        public IQueryable<Transport> GetTransports()
        {
            return iTransportService.GetAllAsync();
        }

        [UseProjection]
        public async Task<Transport?> GetTransport(int pId)
        {
            return await iTransportService.GetByIdAsync(pId);
        }
    }
}
