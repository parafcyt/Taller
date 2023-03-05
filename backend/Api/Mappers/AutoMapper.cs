using Api.Dtos.Destinations;
using Api.Dtos.Hotels;
using Api.Dtos.Transports;
using AutoMapper;
using Domain.Entities;

namespace Api.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateDestinationDto, Destination>();
            CreateMap<UpdateDestinationDto, Destination>();

            CreateMap<CreateDestinationPhotoDto, DestinationPhoto>();
            CreateMap<UpdateDestinationPhotoDto, DestinationPhoto>();

            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<UpdateHotelDto, Hotel>();

            CreateMap<CreateHotelPhotoDto, HotelPhoto>();
            CreateMap<UpdateHotelPhotoDto, HotelPhoto>();

            CreateMap<CreateTransportDto, Transport>();
            CreateMap<UpdateTransportDto, Transport>();
        }
    }
}
