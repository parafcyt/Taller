using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Hotels
{
    public class CreateHotelPhotoInputDto
    {
        [Required]
        public string Url { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]
        public int HotelId { get; set; }
    }
}
