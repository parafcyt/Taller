using Application.Dtos.Destinations;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateDestinationInputDto, Destination>();
            CreateMap<UpdateDestinationInputDto, Destination>();
        }
    }
}
