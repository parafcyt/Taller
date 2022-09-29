using Domain.Entities;
using Domain.Repositories;
using Infraestructure.DataContext;
using Infraestructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class DestinationRepository : Repository<Destination>, IDestinationRepository
    {
        public DestinationRepository(TallerContext pTallerContext) : base(pTallerContext)
        {
        }
    }
}
