using Domain.Entities;
using Domain.Repositories;
using Infraestructure.DataContext;
using Infraestructure.Repositories.Base;

namespace Infraestructure.Repositories
{
    public class RatingScaleRepository : Repository<RatingScale>, IRatingScaleRepository
    {
        public RatingScaleRepository(TallerContext pTallerContext) : base(pTallerContext)
        {
        }
    }
}
