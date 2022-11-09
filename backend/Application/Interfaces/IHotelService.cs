using Application.Dtos.Hotels;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IHotelService
    {
        Task<Hotel?> GetHotelById(int pId);

        IQueryable<Hotel> GetHotels();

        Task<Hotel> AddHotel(CreateHotelInputDto pInput);

        Task<Hotel> UpdateHotel(UpdateHotelInputDto pInput);

        Task DeleteHotel(int pId);
    }
}
