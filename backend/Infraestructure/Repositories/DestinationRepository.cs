using Domain.Entities;
using Domain.Repositories;
using Infraestructure.DataContext;
using Infraestructure.Repositories.Base;

namespace Infraestructure.Repositories
{
    public class DestinationRepository : Repository<Destination>, IDestinationRepository
    {
        public DestinationRepository(TallerContext pTallerContext) : base(pTallerContext)
        {
        }
    }
}
