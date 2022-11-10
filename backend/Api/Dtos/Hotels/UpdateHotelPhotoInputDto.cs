using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Hotels
{
    public class UpdateHotelPhotoInputDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]
        public int HotelId { get; set; }
    }
}
