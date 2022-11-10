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
            CreateMap<CreateDestinationInputDto, Destination>();
            CreateMap<UpdateDestinationInputDto, Destination>();

            CreateMap<CreateDestinationPhotoInputDto, DestinationPhoto>();
            CreateMap<UpdateDestinationPhotoInputDto, DestinationPhoto>();

            CreateMap<CreateHotelInputDto, Hotel>();
            CreateMap<UpdateHotelInputDto, Hotel>();

            CreateMap<CreateHotelPhotoInputDto, HotelPhoto>();
            CreateMap<UpdateHotelPhotoInputDto, HotelPhoto>();

            CreateMap<CreateTransportInputDto, Transport>();
            CreateMap<UpdateTransportInputDto, Transport>();
        }
    }
}
