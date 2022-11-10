using Application.Dtos.Destinations;
using Application.Dtos.Hotels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
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
        }
    }
}
