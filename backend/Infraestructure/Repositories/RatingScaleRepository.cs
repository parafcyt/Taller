using Domain.Entities;
using Domain.Repositories;
using Infraestructure.DataContext;
using Infraestructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class RatingScaleRepository : Repository<RatingScale>, IRatingScaleRepository
    {
        public RatingScaleRepository(TallerContext pTallerContext) : base(pTallerContext)
        {
        }
    }
}
